using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Interfaces
{
  public interface ISecurityAggregateRoot : IAggregateRoot
  {
    public Result<RegisterCredentialDomainResponse> RegisterCredential(
      RegisterCredentialDomainRequest registerData
    );
    public Result<RegisterRoleDomainResponse> RegisterRole(RegisterRoleDomainRequest registerData);
    public Result<UpdateRoleDomainResponse> UpdateRole(UpdateRoleDomainRequest updateData);
    public Result<DeleteRoleDomainResponse> DeleteRole(DeleteRoleDomainRequest deleteData);
    public Result<ActivateTokenDomainResponse> ValidateActivationToken(
      ActivateTokenDomainRequest activateData
    );
    public Result<ActiveCredentialDomainResponse> ActiveCredential(
      ActiveCredentialDomainRequest activeData
    );
    public Result<SignInDataInitialsDomainResponse> ValidateEmailAndEncryptPassword(
      SignInDataInitialsDomainRequest signInData
    );
    public Result<SignInDomainResponse> GenerateTokenForSignIn(SignInDomainRequest signInData);
    public Result<VerifyTokenDomainResponse> VerifyToken(VerifyTokenDomainRequest verifyData);
    public Result<ChangePasswordDomainResponse> ChangePassword(
      ChangePasswordDomainRequest changeData
    );
    public Result<PasswordRecoveryDomainResponse> PasswordRecovery(
      PasswordRecoveryDomainRequest recoveryData
    );
    public Result<UpdateCredentialDomainResponse> UpdateCredential(
      UpdateCredentialDomainRequest updateData
    );
    public Result<ResetPasswordDomainResponse> ResetPassword(ResetPasswordDomainRequest resetData);
  }
}
