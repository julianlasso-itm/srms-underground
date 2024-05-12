using AccessControl.Application.Commands;
using AccessControl.Domain.Aggregates.Dto.Requests;

namespace AccessControl.Application.AntiCorruption.Interfaces
{
  public interface IApplicationToDomain
  {
    public RegisterCredentialDomainRequest ToRegisterCredentialDomainRequest(
      RegisterUserCommand request
    );
    public RegisterRoleDomainRequest ToRegisterRoleDomainRequest(RegisterRoleCommand request);
    public UpdateRoleDomainRequest ToUpdateRoleDomainRequest(UpdateRoleCommand request);
    public DeleteRoleDomainRequest ToDeleteRoleDomainRequest(DeleteRoleCommand request);
    public ActivateTokenDomainRequest ToActivateTokenDomainRequest(ActivateTokenCommand request);
    public ActiveCredentialDomainRequest ToActiveCredentialDomainRequest(ActiveUserCommand request);
  }
}
