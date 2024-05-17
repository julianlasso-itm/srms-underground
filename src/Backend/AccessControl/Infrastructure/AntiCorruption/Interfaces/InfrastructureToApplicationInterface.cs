using AccessControl.Application.Commands;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace AccessControl.Infrastructure.AntiCorruption.Interfaces
{
  public interface IInfrastructureToApplication
  {
    public GetRolesCommand ToGetRolesCommand(GetRolesAccessControlRequest request);
    public RegisterRoleCommand ToRegisterRoleCommand(RegisterRoleAccessControlRequest request);
    public UpdateRoleCommand ToUpdateRoleCommand(UpdateRoleAccessControlRequest request);
    public DeleteRoleCommand ToDeleteRoleCommand(DeleteRoleAccessControlRequest request);
    public RegisterUserCommand ToRegisterUserCommand(RegisterUserRequest request);
    public ActivateTokenCommand ToActivateTokenCommand(ActivationTokenAccessControlRequest request);
    public SignInCommand ToSignInCommand(SignInAccessControlRequest request);
    public VerifyTokenCommand ToVerifyTokenCommand(VerifyTokenAccessControlRequest request);
    public ChangePasswordCommand ToChangePasswordCommand(
      ChangePasswordAccessControlRequest request
    );
  }
}
