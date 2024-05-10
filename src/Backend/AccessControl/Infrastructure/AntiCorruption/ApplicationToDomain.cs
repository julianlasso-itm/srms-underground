using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Domain.Aggregates.Dto.Requests;

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
  }
}
