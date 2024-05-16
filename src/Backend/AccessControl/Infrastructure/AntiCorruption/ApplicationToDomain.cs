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
      return new ActiveCredentialDomainRequest { UserId = request.UserId };
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
  }
}
