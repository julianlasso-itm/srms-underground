using AccessControl.Application.Commands;
using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;

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
    public SignInDataInitialsDomainRequest ToSignInInitialsDomainRequest(SignInCommand request);
    public SignInDomainRequest ToSignInDomainRequest(
      SignInDataInitialsDomainResponse request,
      string userId,
      string name,
      string photoUrl,
      List<string> roles,
      string privateKeyPath,
      string publicKeyPath
    );
    public VerifyTokenDomainRequest ToVerifyTokenDomainRequest(VerifyTokenCommand request);
    public ChangePasswordDomainRequest ToChangePasswordDomainRequest(ChangePasswordCommand request);
    public PasswordRecoveryDomainRequest ToPasswordRecoveryDomainRequest(PasswordRecoveryCommand request);
  }
}
