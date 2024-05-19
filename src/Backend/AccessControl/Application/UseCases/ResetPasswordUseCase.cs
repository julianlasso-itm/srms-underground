using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace Application.UseCases
{
  public class ResetPasswordUseCase<TEntity>
    : BaseUseCase<
      ResetPasswordCommand,
      ResetPasswordApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly ICacheService _cacheService;
    private readonly IUserRepository<TEntity> _repository;

    public ResetPasswordUseCase(
      ICacheService cacheService,
      IUserRepository<TEntity> repository,
      ISecurityAggregateRoot aggregateRoot,
      IApplicationToDomain aclInputMapper,
      IDomainToApplication aclOutputMapper
    )
      : base(aggregateRoot, aclInputMapper, aclOutputMapper)
    {
      _cacheService = cacheService;
      _repository = repository;
    }

    public override async Task<ResetPasswordApplicationResponse> Handle(
      ResetPasswordCommand request
    )
    {
      var command = AclInputMapper.ToResetPasswordDomainRequest(request);
      var user = AggregateRoot.ResetPassword(command);
      var email = GetEmailFromCache(request.Token);
      await Persist(email, user.Password);
      RemoveTokenFromCache(request.Token);
      return AclOutputMapper.ToResetPasswordApplicationResponse();
    }

    private string GetEmailFromCache(string token)
    {
      return _cacheService.Get("recovery:" + token)
        ?? throw new ApplicationException("Token not found", HttpStatusCode.NotFound);
    }

    private async Task Persist(string email, string password)
    {
      var user = await _repository.GetByEmail(email);
      await _repository.UpdatePassword(user.UserId, password);
    }

    private void RemoveTokenFromCache(string token)
    {
      _cacheService.Remove("recovery:" + token);
    }
  }
}
