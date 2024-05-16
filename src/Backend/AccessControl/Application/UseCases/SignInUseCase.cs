using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using AccessControlApplication.Dto;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace AccessControl.Application.UseCases
{
  public sealed class SignInUseCase<TEntity>
    : BaseUseCase<
      SignInCommand,
      SignInApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    // private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialActivated}";
    private readonly IUserRepository<TEntity> _userRepository;
    private readonly ICacheService _cacheService;

    public SignInUseCase(
      IUserRepository<TEntity> userRepository,
      ICacheService cacheService,
      ISecurityAggregateRoot aggregateRoot,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _userRepository = userRepository;
      _cacheService = cacheService;
    }

    public override async Task<SignInApplicationResponse> Handle(SignInCommand request)
    {
      CheckIfUserIsTemporarilyBlocked(request.Email);
      var command = AclInputMapper.ToSignInInitialsDomainRequest(request);
      var user = AggregateRoot.ValidateEmailAndEncryptPassword(command);
      var data = await VerifyUserAndPassword(user.Email, user.Password);
      var signInData = AclInputMapper.ToSignInDomainRequest(
        user,
        data.UserId,
        data.Name,
        data.Photo,
        data.Roles,
        command.PrivateKeyPath,
        command.PublicKeyPath
      );
      var response = AggregateRoot.GenerateTokenForSignIn(signInData);
      return AclOutputMapper.ToSignInApplicationResponse(response);
    }

    private void CheckIfUserIsTemporarilyBlocked(string email)
    {
      if (_cacheService.Get($"{email}_temporarily_blocked") != null)
      {
        throw new ApplicationException("User is temporarily blocked", HttpStatusCode.Forbidden);
      }
    }

    private void BlockUserTemporarily(string email)
    {
      _cacheService.Set($"{email}_temporarily_blocked", email, TimeSpan.FromMinutes(5));
      throw new ApplicationException("User is temporarily blocked", HttpStatusCode.Forbidden);
    }

    private async Task<UserDataForSigInDto> VerifyUserAndPassword(string email, string password)
    {
      try
      {
        return await _userRepository.GetByEmailAndPassword(email, password);
      }
      catch (ApplicationException)
      {
        VerifyPreviousAttempts(email);
        throw new ApplicationException("Invalid credentials", HttpStatusCode.Unauthorized);
      }
    }

    private void VerifyPreviousAttempts(string email)
    {
      var path = $"{email}_attempts";
      var attempts = _cacheService.GetListLength(path);

      if (attempts == 0)
      {
        _cacheService.AddToList(path, "strike", TimeSpan.FromMinutes(5));
        return;
      }

      if (attempts < 3)
      {
        _cacheService.AddToList(path, "strike");
        return;
      }

      if (attempts == 3)
      {
        _cacheService.Remove(path);
        BlockUserTemporarily(email);
      }
    }
  }
}
