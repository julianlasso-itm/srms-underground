using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

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
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, aclInputMapper, aclOutputMapper)
    where TEntity : class
  {
    private readonly ICacheService _cacheService = cacheService;
    private readonly IUserRepository<TEntity> _repository = repository;

    public override async Task<Result> Handle(ResetPasswordCommand request)
    {
      var command = AclInputMapper.ToResetPasswordDomainRequest(request);
      var response = AggregateRoot.ResetPassword(command);

      if (response.IsFailure)
      {
        return response;
      }

      if (response is SuccessResult<ResetPasswordDomainResponse> successResult)
      {
        var data = successResult.Data;
        var email = GetEmailFromCache(request.Token);
        if (string.IsNullOrEmpty(email))
        {
          return new ErrorResult("Token not found", ErrorEnum.NOT_FOUND);
        }
        await Persist(email, data.Password);
        RemoveTokenFromCache(request.Token);
        return new SuccessResult<ResetPasswordApplicationResponse>(
          AclOutputMapper.ToResetPasswordApplicationResponse()
        );
      }

      throw new ApplicationException(
        "Invalid response into ResetPasswordUseCase for AccessControl application",
        HttpStatusCode.InternalServerError
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
