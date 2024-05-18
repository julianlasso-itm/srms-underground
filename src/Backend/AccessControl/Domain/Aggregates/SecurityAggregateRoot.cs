using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Helpers;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace AccessControl.Domain.Aggregates
{
  public class SecurityAggregateRoot : BaseAggregateRoot, ISecurityAggregateRoot
  {
    public SecurityAggregateRoot(IEvent eventInterface)
      : base(eventInterface) { }

    public RegisterCredentialDomainResponse RegisterCredential(
      RegisterCredentialDomainRequest registerData
    )
    {
      return RegisterCredentialHelper.Execute(registerData);
    }

    public RegisterRoleDomainResponse RegisterRole(RegisterRoleDomainRequest registerData)
    {
      return RegisterRoleHelper.Execute(registerData);
    }

    public UpdateRoleDomainResponse UpdateRole(UpdateRoleDomainRequest updateData)
    {
      return UpdateRoleHelper.Execute(updateData);
    }

    public DeleteRoleDomainResponse DeleteRole(DeleteRoleDomainRequest deleteData)
    {
      return DeleteRoleHelper.Execute(deleteData);
    }

    public ActivateTokenDomainResponse ValidateActivationToken(
      ActivateTokenDomainRequest activateData
    )
    {
      return ValidateActivationTokenHelper.Execute(activateData);
    }

    public ActiveCredentialDomainResponse ActiveCredential(ActiveCredentialDomainRequest activeData)
    {
      return ActiveCredentialHelper.Execute(activeData);
    }

    public SignInDataInitialsDomainResponse ValidateEmailAndEncryptPassword(
      SignInDataInitialsDomainRequest signInData
    )
    {
      return ValidateEmailAndEncryptPasswordHelper.Execute(signInData);
    }

    public SignInDomainResponse GenerateTokenForSignIn(SignInDomainRequest signInData)
    {
      return GenerateTokenForSignInHelper.Execute(signInData);
    }

    public VerifyTokenDomainResponse VerifyToken(VerifyTokenDomainRequest verifyData)
    {
      return VerifyTokenHelper.Execute(verifyData);
    }

    public ChangePasswordDomainResponse ChangePassword(ChangePasswordDomainRequest changeData)
    {
      return ChangePasswordHelper.Execute(changeData);
    }

    public PasswordRecoveryDomainResponse PasswordRecovery(
      PasswordRecoveryDomainRequest recoveryData
    )
    {
      return PasswordRecoveryHelper.Execute(recoveryData);
    }

    public UpdateCredentialDomainResponse UpdateCredential(UpdateCredentialDomainRequest updateData)
    {
      return UpdateCredentialHelper.Execute(updateData);
    }
  }
}
