using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Common.Enums;

namespace AccessControl.Application.UseCases
{
  public sealed class ResetPasswordUseCase<TEntity>(
    ICacheService cacheService,
    IUserRepository<TEntity> repository,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain aclInputMapper,
    IDomainToApplication aclOutputMapper
  )
    : BaseUseCase<
      ResetPasswordCommand,
      ResetPasswordApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, aclInputMapper, aclOutputMapper)
    where TEntity : class
  {
    private readonly ICacheService _cacheService = cacheService;
    private readonly IUserRepository<TEntity> _repository = repository;

    public override async Task<Result<ResetPasswordApplicationResponse>> Handle(
      ResetPasswordCommand request
    )
    {
      var command = AclInputMapper.ToResetPasswordDomainRequest(request);
      var response = AggregateRoot.ResetPassword(command);

      if (response.IsFailure)
      {
        return Response<ResetPasswordApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var data = response.Data;
      var email = GetEmailFromCache(request.Token);
      if (string.IsNullOrEmpty(email))
      {
        return Response<ResetPasswordApplicationResponse>.Failure(
          "Token not found",
          ErrorEnum.NOT_FOUND
        );
      }
      await Persist(email, data.Password);
      RemoveTokenFromCache(request.Token);
      return Response<ResetPasswordApplicationResponse>.Success(
        AclOutputMapper.ToResetPasswordApplicationResponse()
      );
    }

    private string GetEmailFromCache(string token)
    {
      return _cacheService.Get("recovery:" + token) ?? string.Empty;
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
