using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.AntiCorruption.Interfaces
{
  public interface IApplicationToInfrastructure
  {
    public GetRolesAccessControlResponse ToGetRolesResponse(
      GetRolesApplicationResponse<RoleModel> data
    );
    public RegisterRoleAccessControlResponse ToRegisterRoleResponse(
      RegisterRoleApplicationResponse data
    );
    public UpdateRoleAccessControlResponse ToUpdateRoleResponse(UpdateRoleApplicationResponse data);
    public DeleteRoleAccessControlResponse ToDeleteRoleResponse(DeleteRoleApplicationResponse data);
    public RegisterUserResponse ToRegisterUserResponse(RegisterUserApplicationResponse data);
    public ActivationTokenAccessControlResponse ToActivateTokenResponse(
      ActivationTokenApplicationResponse data
    );
    public SignInAccessControlResponse ToSignInResponse(SignInApplicationResponse data);
    public VerifyTokenAccessControlResponse ToVerifyTokenResponse(
      VerifyTokenApplicationResponse data
    );
    public ChangePasswordAccessControlResponse ToChangePasswordResponse(
      ChangePasswordApplicationResponse data
    );
    public PasswordRecoveryAccessControlResponse ToPasswordRecoveryResponse(
      PasswordRecoveryApplicationResponse data
    );
  }
}
