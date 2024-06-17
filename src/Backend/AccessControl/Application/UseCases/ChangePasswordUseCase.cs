using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

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

    public override async Task<ChangePasswordApplicationResponse> Handle(
      ChangePasswordCommand request
    )
    {
      var command = AclInputMapper.ToChangePasswordDomainRequest(request);
      var user = AggregateRoot.ChangePassword(command);
      await VerifyCurrentPassword(user.CredentialId, user.OldPassword);
      await UpdatePasswordInDatabase(user.CredentialId, user.NewPassword);
      return AclOutputMapper.ToChangePasswordApplicationResponse();
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
