using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common;

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
      ChangePasswordApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, aclInputMapper, aclOutputMapper)
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository = userRepository;

    public override async Task<Result<ChangePasswordApplicationResponse>> Handle(
      ChangePasswordCommand request
    )
    {
      var command = AclInputMapper.ToChangePasswordDomainRequest(request);
      var response = AggregateRoot.ChangePassword(command);

      if (response.IsFailure)
      {
        return Response<ChangePasswordApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var user = response.Data;
      await VerifyCurrentPassword(user.CredentialId, user.OldPassword);
      await UpdatePasswordInDatabase(user.CredentialId, user.NewPassword);
      return Response<ChangePasswordApplicationResponse>.Success(
        AclOutputMapper.ToChangePasswordApplicationResponse()
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
