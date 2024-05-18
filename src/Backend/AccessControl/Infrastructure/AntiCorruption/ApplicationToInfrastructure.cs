using AccessControl.Application.Responses;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class ApplicationToInfrastructure : IApplicationToInfrastructure
  {
    private static ApplicationToInfrastructure s_instance;

    public static ApplicationToInfrastructure Instance
    {
      get
      {
        s_instance ??= new ApplicationToInfrastructure();
        return s_instance;
      }
    }

    public GetRolesAccessControlResponse ToGetRolesResponse(
      GetRolesApplicationResponse<RoleModel> data
    )
    {
      return new GetRolesAccessControlResponse
      {
        Roles = data
          .Roles.Select(role => new RoleSecurity
          {
            RoleId = role.RoleId.ToString(),
            Name = role.Name,
            Description = role.Description,
            Disabled = role.Disabled
          })
          .ToList(),
        Total = data.Total
      };
    }

    public RegisterRoleAccessControlResponse ToRegisterRoleResponse(
      RegisterRoleApplicationResponse data
    )
    {
      return new RegisterRoleAccessControlResponse
      {
        RoleId = data.RoleId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
      };
    }

    public UpdateRoleAccessControlResponse ToUpdateRoleResponse(UpdateRoleApplicationResponse data)
    {
      return new UpdateRoleAccessControlResponse
      {
        RoleId = data.RoleId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
      };
    }

    public DeleteRoleAccessControlResponse ToDeleteRoleResponse(DeleteRoleApplicationResponse data)
    {
      return new DeleteRoleAccessControlResponse { RoleId = data.RoleId };
    }

    public RegisterUserResponse ToRegisterUserResponse(RegisterUserApplicationResponse data)
    {
      return new RegisterUserResponse { Success = data.UserId != null, };
    }

    public ActivationTokenAccessControlResponse ToActivateTokenResponse(
      ActivationTokenApplicationResponse data
    )
    {
      return new ActivationTokenAccessControlResponse
      {
        IsAuthorized = data.ActivationToken != null,
      };
    }

    public SignInAccessControlResponse ToSignInResponse(SignInApplicationResponse data)
    {
      return new SignInAccessControlResponse { Token = data.Token };
    }

    public VerifyTokenAccessControlResponse ToVerifyTokenResponse(
      VerifyTokenApplicationResponse data
    )
    {
      return new VerifyTokenAccessControlResponse
      {
        UserId = data.UserId,
        Email = data.Email,
        Roles = data.Roles
      };
    }

    public ChangePasswordAccessControlResponse ToChangePasswordResponse(
      ChangePasswordApplicationResponse data
    )
    {
      return new ChangePasswordAccessControlResponse { Success = data.Success };
    }

    public PasswordRecoveryAccessControlResponse ToPasswordRecoveryResponse(
      PasswordRecoveryApplicationResponse data
    )
    {
      return new PasswordRecoveryAccessControlResponse { Success = data.Success };
    }

    public UpdateUserAccessControlResponse ToUpdateUserResponse(UpdateUserApplicationResponse data)
    {
      return new UpdateUserAccessControlResponse
      {
        UserId = data.UserId,
        Name = data.Name,
        Photo = data.Photo,
        Disabled = data.Disabled,
      };
    }
  }
}
