using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases
{
  public sealed class ChangePasswordUseCase<TEntity>
    : BaseUseCase<
      ChangePasswordCommand,
      ChangePasswordApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository;

    public ChangePasswordUseCase(
      IUserRepository<TEntity> userRepository,
      ISecurityAggregateRoot aggregateRoot,
      IApplicationToDomain aclInputMapper,
      IDomainToApplication aclOutputMapper
    )
      : base(aggregateRoot, aclInputMapper, aclOutputMapper)
    {
      _userRepository = userRepository;
    }

    public override Task<ChangePasswordApplicationResponse> Handle(ChangePasswordCommand request)
    {
      var command = AclInputMapper.ToChangePasswordDomainRequest(request);
      var user = AggregateRoot.ChangePassword(command);
      VerifyCurrentPassword(user.CredentialId, user.OldPassword);
      UpdatePasswordInDatabase(user.CredentialId, user.NewPassword);
      return Task.FromResult(AclOutputMapper.ToChangePasswordApplicationResponse());
    }

    private async void VerifyCurrentPassword(string userId, string password)
    {
      _ = await _userRepository.VerifyPassword(userId, password);
    }

    private async void UpdatePasswordInDatabase(string userId, string password)
    {
      _ = await _userRepository.UpdatePassword(userId, password);
    }
  }
}
