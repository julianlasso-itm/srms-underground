using AccessControl.Domain.Aggregates.Dto.Requests;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Interfaces
{
  public interface ISecurityAggregateRoot : IAggregateRoot
  {
    public Result RegisterCredential(RegisterCredentialDomainRequest registerData);
    public Result RegisterRole(RegisterRoleDomainRequest registerData);
    public Result UpdateRole(UpdateRoleDomainRequest updateData);
    public Result DeleteRole(DeleteRoleDomainRequest deleteData);
    public Result ValidateActivationToken(ActivateTokenDomainRequest activateData);
    public Result ActiveCredential(ActiveCredentialDomainRequest activeData);
    public Result ValidateEmailAndEncryptPassword(SignInDataInitialsDomainRequest signInData);
    public Result GenerateTokenForSignIn(SignInDomainRequest signInData);
    public Result VerifyToken(VerifyTokenDomainRequest verifyData);
    public Result ChangePassword(ChangePasswordDomainRequest changeData);
    public Result PasswordRecovery(PasswordRecoveryDomainRequest recoveryData);
    public Result UpdateCredential(UpdateCredentialDomainRequest updateData);
    public Result ResetPassword(ResetPasswordDomainRequest resetData);
  }
}
