using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class ApplicationToDomain : IApplicationToDomain
  {
    private static ApplicationToDomain s_instance;

    public static ApplicationToDomain Instance
    {
      get
      {
        s_instance ??= new ApplicationToDomain();
        return s_instance;
      }
    }

    public RegisterRoleDomainRequest ToRegisterRoleDomainRequest(RegisterRoleCommand request)
    {
      return new RegisterRoleDomainRequest
      {
        Name = request.Name,
        Description = request.Description,
      };
    }

    public UpdateRoleDomainRequest ToUpdateRoleDomainRequest(UpdateRoleCommand request)
    {
      return new UpdateRoleDomainRequest
      {
        RoleId = request.RoleId,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable,
      };
    }

    public DeleteRoleDomainRequest ToDeleteRoleDomainRequest(DeleteRoleCommand request)
    {
      return new DeleteRoleDomainRequest { RoleId = request.RoleId };
    }

    public RegisterCredentialDomainRequest ToRegisterCredentialDomainRequest(
      RegisterUserCommand request
    )
    {
      return new RegisterCredentialDomainRequest
      {
        Name = request.Name,
        Email = request.Email,
        Password = request.Password,
        Avatar = request.AvatarBytes ?? new byte[0],
      };
    }

    public ActivateTokenDomainRequest ToActivateTokenDomainRequest(ActivateTokenCommand request)
    {
      return new ActivateTokenDomainRequest { ActivationToken = request.ActivationToken };
    }

    public ActiveCredentialDomainRequest ToActiveCredentialDomainRequest(ActiveUserCommand request)
    {
      return new ActiveCredentialDomainRequest { CredentialId = request.UserId };
    }

    public SignInDataInitialsDomainRequest ToSignInInitialsDomainRequest(SignInCommand request)
    {
      return new SignInDataInitialsDomainRequest
      {
        Email = request.Email,
        Password = request.Password,
        PrivateKeyPath = request.PrivateKeyPath,
        PublicKeyPath = request.PublicKeyPath,
      };
    }

    public SignInDomainRequest ToSignInDomainRequest(
      SignInDataInitialsDomainResponse request,
      string userId,
      string name,
      string photoUrl,
      List<string> roles,
      string privateKeyPath,
      string publicKeyPath
    )
    {
      return new SignInDomainRequest
      {
        CredentialId = userId,
        Name = name,
        Email = request.Email,
        Photo = photoUrl,
        Roles = roles,
        PrivateKeyPath = privateKeyPath,
        PublicKeyPath = publicKeyPath,
      };
    }

    public VerifyTokenDomainRequest ToVerifyTokenDomainRequest(VerifyTokenCommand request)
    {
      return new VerifyTokenDomainRequest
      {
        Token = request.Token,
        PrivateKeyPath = request.PrivateKeyPath,
        PublicKeyPath = request.PublicKeyPath,
      };
    }

    public ChangePasswordDomainRequest ToChangePasswordDomainRequest(ChangePasswordCommand request)
    {
      return new ChangePasswordDomainRequest
      {
        CredentialId = request.UserId,
        OldPassword = request.OldPassword,
        NewPassword = request.NewPassword,
      };
    }

    public PasswordRecoveryDomainRequest ToPasswordRecoveryDomainRequest(
      PasswordRecoveryCommand request
    )
    {
      return new PasswordRecoveryDomainRequest { Email = request.Email };
    }

    public UpdateCredentialDomainRequest ToUpdateUserDomainRequest(UpdateUserCommand request)
    {
      return new UpdateCredentialDomainRequest
      {
        CredentialId = request.UserId,
        Name = request.Name,
        Avatar = request.AvatarBytes,
        AvatarExtension = request.AvatarExtension,
        Disabled = request.Disabled,
        CityId = request.CityId,
      };
    }

    public ResetPasswordDomainRequest ToResetPasswordDomainRequest(ResetPasswordCommand request)
    {
      return new ResetPasswordDomainRequest { Password = request.Password };
    }
  }
}
