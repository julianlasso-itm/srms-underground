using AccessControl.Application.Commands;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class InfrastructureToApplication : IInfrastructureToApplication
  {
    private static InfrastructureToApplication s_instance;

    public static InfrastructureToApplication Instance
    {
      get
      {
        s_instance ??= new InfrastructureToApplication();
        return s_instance;
      }
    }

    public GetRolesCommand ToGetRolesCommand(GetRolesAccessControlRequest request)
    {
      return new GetRolesCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        FilterBy = request.FilterBy,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    public RegisterRoleCommand ToRegisterRoleCommand(RegisterRoleAccessControlRequest request)
    {
      return new RegisterRoleCommand { Name = request.Name, Description = request.Description };
    }

    public UpdateRoleCommand ToUpdateRoleCommand(UpdateRoleAccessControlRequest request)
    {
      return new UpdateRoleCommand
      {
        RoleId = request.RoleId!,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable
      };
    }

    public DeleteRoleCommand ToDeleteRoleCommand(DeleteRoleAccessControlRequest request)
    {
      return new DeleteRoleCommand { RoleId = request.RoleId };
    }

    public RegisterUserCommand ToRegisterUserCommand(RegisterUserRequest request)
    {
      return new RegisterUserCommand
      {
        Name = request.Name,
        Email = request.Email,
        Password = request.Password,
        Avatar = request.Avatar,
        AvatarExtension = request.AvatarExtension,
        CityId = request.CityId,
      };
    }

    public ActivateTokenCommand ToActivateTokenCommand(ActivationTokenAccessControlRequest request)
    {
      return new ActivateTokenCommand { ActivationToken = request.ActivationToken };
    }

    public SignInCommand ToSignInCommand(SignInAccessControlRequest request)
    {
      return new SignInCommand
      {
        Email = request.Email,
        Password = request.Password,
        PrivateKeyPath =
          request.PrivateKeyPath ?? throw new ArgumentNullException(nameof(request.PrivateKeyPath)),
        PublicKeyPath =
          request.PublicKeyPath ?? throw new ArgumentNullException(nameof(request.PublicKeyPath)),
      };
    }

    public VerifyTokenCommand ToVerifyTokenCommand(VerifyTokenAccessControlRequest request)
    {
      return new VerifyTokenCommand
      {
        Token = request.Token,
        PrivateKeyPath =
          request.PrivateKeyPath ?? throw new ArgumentNullException(nameof(request.PrivateKeyPath)),
        PublicKeyPath =
          request.PublicKeyPath ?? throw new ArgumentNullException(nameof(request.PublicKeyPath)),
      };
    }

    public ChangePasswordCommand ToChangePasswordCommand(ChangePasswordAccessControlRequest request)
    {
      return new ChangePasswordCommand
      {
        UserId = request.UserId!,
        OldPassword = request.OldPassword,
        NewPassword = request.NewPassword,
      };
    }

    public PasswordRecoveryCommand ToPasswordRecoveryCommand(
      PasswordRecoveryAccessControlRequest request
    )
    {
      return new PasswordRecoveryCommand { Email = request.Email };
    }

    public UpdateUserCommand ToUpdateUserCommand(UpdateUserAccessControlRequest request)
    {
      return new UpdateUserCommand
      {
        UserId = request.UserId,
        Name = request.Name,
        Avatar = request.Avatar,
        AvatarExtension = request.AvatarExtension,
        OldPhoto = request.OldPhoto,
        Disabled = request.Disabled,
        CityId = request.CityId,
      };
    }

    public ResetPasswordCommand ToResetPasswordCommand(ResetPasswordAccessControlRequest request)
    {
      return new ResetPasswordCommand { Token = request.Token, Password = request.Password };
    }
  }
}
