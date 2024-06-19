using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace AccessControl.Application.UseCases
{
  public sealed class ChangePasswordUseCase<TEntity>(
    IUserRepository<TEntity> userRepository,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain aclInputMapper,
    IDomainToApplication aclOutputMapper
  )
    : BaseUseCase<
      ChangePasswordCommand,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, aclInputMapper, aclOutputMapper)
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository = userRepository;

    public override async Task<Result> Handle(ChangePasswordCommand request)
    {
      var command = AclInputMapper.ToChangePasswordDomainRequest(request);
      var response = AggregateRoot.ChangePassword(command);

      if (response.IsFailure)
      {
        return response;
      }

      if (response is SuccessResult<ChangePasswordDomainResponse> successResult)
      {
        var user = successResult.Data;
        await VerifyCurrentPassword(user.CredentialId, user.OldPassword);
        await UpdatePasswordInDatabase(user.CredentialId, user.NewPassword);
        return new SuccessResult<ChangePasswordApplicationResponse>(
          AclOutputMapper.ToChangePasswordApplicationResponse()
        );
      }

      throw new ApplicationException(
        "Invalid response into ChangePasswordUseCase for AccessControl application",
        HttpStatusCode.InternalServerError
      );
    }

    private async Task VerifyCurrentPassword(string userId, string password)
    {
      _ = await _userRepository.VerifyPassword(userId, password);
    }

    private async Task UpdatePasswordInDatabase(string userId, string password)
    {
      _ = await _userRepository.UpdatePassword(userId, password);
    }
  }
}
