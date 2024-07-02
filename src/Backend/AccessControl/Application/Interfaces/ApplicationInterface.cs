using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using Shared.Common;

namespace AccessControl.Application.Interfaces
{
  public interface IApplication<TRoleEntity>
    where TRoleEntity : class
  {
    Task<Result<RegisterUserApplicationResponse>> RegisterUser(RegisterUserCommand request);
    Task<Result<RegisterRoleApplicationResponse>> RegisterRole(RegisterRoleCommand request);
    Task<Result<UpdateRoleApplicationResponse>> UpdateRole(UpdateRoleCommand request);
    Task<Result<DeleteRoleApplicationResponse>> DeleteRole(DeleteRoleCommand request);
    Task<Result<GetRolesApplicationResponse<TRoleEntity>>> GetRoles(GetRolesCommand request);
    Task<Result<ActivationTokenApplicationResponse>> ActivateToken(ActivateTokenCommand request);
    Task<Result<SignInApplicationResponse>> SignIn(SignInCommand request);
    Task<Result<VerifyTokenApplicationResponse>> VerifyToken(VerifyTokenCommand request);
    Task<Result<ChangePasswordApplicationResponse>> ChangePassword(ChangePasswordCommand request);
    Task<Result<PasswordRecoveryApplicationResponse>> PasswordRecovery(
      PasswordRecoveryCommand request
    );
    Task<Result<UpdateUserApplicationResponse>> UpdateUser(UpdateUserCommand request);
    Task<Result<ResetPasswordApplicationResponse>> ResetPassword(ResetPasswordCommand request);
  }
}
