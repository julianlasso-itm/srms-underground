using AccessControl.Application.Commands;
using Shared.Common.Bases;

namespace AccessControl.Application.Interfaces
{
  public interface IApplication
  {
    Task<Result> RegisterUser(RegisterUserCommand request);
    Task<Result> RegisterRole(RegisterRoleCommand request);
    Task<Result> UpdateRole(UpdateRoleCommand request);
    Task<Result> DeleteRole(DeleteRoleCommand request);
    Task<Result> GetRoles(GetRolesCommand request);
    Task<Result> ActivateToken(ActivateTokenCommand request);
    Task<Result> SignIn(SignInCommand request);
    Task<Result> VerifyToken(VerifyTokenCommand request);
    Task<Result> ChangePassword(ChangePasswordCommand request);
    Task<Result> PasswordRecovery(PasswordRecoveryCommand request);
    Task<Result> UpdateUser(UpdateUserCommand request);
    Task<Result> ResetPassword(ResetPasswordCommand request);
  }
}
