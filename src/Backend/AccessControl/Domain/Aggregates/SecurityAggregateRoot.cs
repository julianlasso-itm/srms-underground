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
    public Result<RegisterCredentialDomainResponse> RegisterCredential(
      RegisterCredentialDomainRequest registerData
    )
    {
      return RegisterCredentialHelper.Execute(registerData);
    }

    public Result<RegisterRoleDomainResponse> RegisterRole(RegisterRoleDomainRequest registerData)
    {
      return RegisterRoleHelper.Execute(registerData);
    }

    public Result<UpdateRoleDomainResponse> UpdateRole(UpdateRoleDomainRequest updateData)
    {
      return UpdateRoleHelper.Execute(updateData);
    }

    public Result<DeleteRoleDomainResponse> DeleteRole(DeleteRoleDomainRequest deleteData)
    {
      return DeleteRoleHelper.Execute(deleteData);
    }

    public Result<ActivateTokenDomainResponse> ValidateActivationToken(
      ActivateTokenDomainRequest activateData
    )
    {
      return ValidateActivationTokenHelper.Execute(activateData);
    }

    public Result<ActiveCredentialDomainResponse> ActiveCredential(
      ActiveCredentialDomainRequest activeData
    )
    {
      return ActiveCredentialHelper.Execute(activeData);
    }

    public Result<SignInDataInitialsDomainResponse> ValidateEmailAndEncryptPassword(
      SignInDataInitialsDomainRequest signInData
    )
    {
      return ValidateEmailAndEncryptPasswordHelper.Execute(signInData);
    }

    public Result<SignInDomainResponse> GenerateTokenForSignIn(SignInDomainRequest signInData)
    {
      return GenerateTokenForSignInHelper.Execute(signInData);
    }

    public Result<VerifyTokenDomainResponse> VerifyToken(VerifyTokenDomainRequest verifyData)
    {
      return VerifyTokenHelper.Execute(verifyData);
    }

    public Result<ChangePasswordDomainResponse> ChangePassword(
      ChangePasswordDomainRequest changeData
    )
    {
      return ChangePasswordHelper.Execute(changeData);
    }

    public Result<PasswordRecoveryDomainResponse> PasswordRecovery(
      PasswordRecoveryDomainRequest recoveryData
    )
    {
      return PasswordRecoveryHelper.Execute(recoveryData);
    }

    public Result<UpdateCredentialDomainResponse> UpdateCredential(
      UpdateCredentialDomainRequest updateData
    )
    {
      return UpdateCredentialHelper.Execute(updateData);
    }

    public Result<ResetPasswordDomainResponse> ResetPassword(ResetPasswordDomainRequest resetData)
    {
      return ResetPasswordHelper.Execute(resetData);
    }
  }
}
