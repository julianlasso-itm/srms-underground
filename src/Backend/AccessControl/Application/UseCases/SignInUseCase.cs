using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Dto;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace AccessControl.Application.UseCases
{
  public sealed class SignInUseCase<TEntity>(
    IUserRepository<TEntity> userRepository,
    ICacheService cacheService,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      SignInCommand,
      SignInApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    // private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialActivated}";
    private readonly IUserRepository<TEntity> _userRepository = userRepository;
    private readonly ICacheService _cacheService = cacheService;
    private const int MaxAttempts = 3;
    private const int MaxAttemptsMinutes = 5;
    private const int MaxBlockMinutes = 5;

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
      _cacheService.Set(
        $"{email}_temporarily_blocked",
        email,
        TimeSpan.FromMinutes(MaxBlockMinutes)
      );
      throw new ApplicationException("User is temporarily blocked", HttpStatusCode.Forbidden);
    }

    private async Task<UserDataForSigInDto> VerifyUserAndPassword(string email, string password)
    {
      try
      {
        var data = await _userRepository.GetByEmailAndPassword(email, password);
        DeletePreviousAttempts(email);
        return data;
      }
      catch (Exception)
      {
        VerifyPreviousAttempts(email);
        throw new ApplicationException(
          "User not found or credentials incorrect!",
          HttpStatusCode.Unauthorized
        );
      }
    }

    private void DeletePreviousAttempts(string email)
    {
      _cacheService.Remove($"{email}_attempts");
    }

    private void VerifyPreviousAttempts(string email)
    {
      var path = $"{email}_attempts";
      var attempts = _cacheService.GetListLength(path);

      if (attempts == 0)
      {
        _cacheService.AddToList(path, "strike", TimeSpan.FromMinutes(MaxAttemptsMinutes));
        return;
      }

      if (attempts < MaxAttempts - 1)
      {
        _cacheService.AddToList(path, "strike");
        return;
      }

      if (attempts == MaxAttempts - 1)
      {
        _cacheService.Remove(path);
        BlockUserTemporarily(email);
      }
    }
  }
}
