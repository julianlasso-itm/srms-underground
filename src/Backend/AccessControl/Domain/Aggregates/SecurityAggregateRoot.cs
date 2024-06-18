using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Helpers;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Events.Interfaces;

namespace AccessControl.Domain.Aggregates
{
  public class SecurityAggregateRoot(IEvent eventInterface)
    : BaseAggregateRoot(eventInterface),
      ISecurityAggregateRoot
  {
    public Result RegisterCredential(RegisterCredentialDomainRequest registerData)
    {
      return RegisterCredentialHelper.Execute(registerData);
    }

    public Result RegisterRole(RegisterRoleDomainRequest registerData)
    {
      return RegisterRoleHelper.Execute(registerData);
    }

    public Result UpdateRole(UpdateRoleDomainRequest updateData)
    {
      return UpdateRoleHelper.Execute(updateData);
    }

    public Result DeleteRole(DeleteRoleDomainRequest deleteData)
    {
      return DeleteRoleHelper.Execute(deleteData);
    }

    public Result ValidateActivationToken(ActivateTokenDomainRequest activateData)
    {
      return ValidateActivationTokenHelper.Execute(activateData);
    }

    public Result ActiveCredential(ActiveCredentialDomainRequest activeData)
    {
      return ActiveCredentialHelper.Execute(activeData);
    }

    public Result ValidateEmailAndEncryptPassword(SignInDataInitialsDomainRequest signInData)
    {
      return ValidateEmailAndEncryptPasswordHelper.Execute(signInData);
    }

    public Result GenerateTokenForSignIn(SignInDomainRequest signInData)
    {
      return GenerateTokenForSignInHelper.Execute(signInData);
    }

    public Result VerifyToken(VerifyTokenDomainRequest verifyData)
    {
      return VerifyTokenHelper.Execute(verifyData);
    }

    public Result ChangePassword(ChangePasswordDomainRequest changeData)
    {
      return ChangePasswordHelper.Execute(changeData);
    }

    public Result PasswordRecovery(PasswordRecoveryDomainRequest recoveryData)
    {
      return PasswordRecoveryHelper.Execute(recoveryData);
    }

    public Result UpdateCredential(UpdateCredentialDomainRequest updateData)
    {
      return UpdateCredentialHelper.Execute(updateData);
    }

    public Result ResetPassword(ResetPasswordDomainRequest resetData)
    {
      return ResetPasswordHelper.Execute(resetData);
    }
  }
}
