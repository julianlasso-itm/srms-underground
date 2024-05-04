using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Dto.Responses;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class DomainToApplication : IDomainToApplication
  {
    private static DomainToApplication s_instance;

    public static DomainToApplication Instance
    {
      get
      {
        s_instance ??= new DomainToApplication();
        return s_instance;
      }
    }

    public GetRolesApplicationResponse<TEntity> ToGetRolesApplicationResponse<TEntity>(
      IEnumerable<TEntity> roles,
      int total
    )
      where TEntity : class
    {
      return new GetRolesApplicationResponse<TEntity> { Roles = roles, Total = total };
    }

    public RegisterRoleApplicationResponse ToRegisterRoleApplicationResponse(
      RegisterRoleDomainResponse role
    )
    {
      return new RegisterRoleApplicationResponse
      {
        RoleId = role.RoleId,
        Name = role.Name,
        Description = role.Description,
        Disabled = role.Disabled,
      };
    }

    public UpdateRoleApplicationResponse ToUpdateRoleApplicationResponse(
      UpdateRoleDomainResponse role
    )
    {
      return new UpdateRoleApplicationResponse
      {
        RoleId = role.RoleId,
        Name = role.Name,
        Description = role.Description,
        Disabled = role.Disabled,
      };
    }

    public DeleteRoleApplicationResponse ToDeleteRoleApplicationResponse(
      DeleteRoleDomainResponse role
    )
    {
      return new DeleteRoleApplicationResponse { RoleId = role.RoleId };
    }

    public RegisterUserApplicationResponse ToRegisterUserApplicationResponse(
      RegisterCredentialDomainResponse user
    )
    {
      return new RegisterUserApplicationResponse
      {
        UserId = user.CredentialId,
        Email = user.Email,
        Password = user.Password,
        Disabled = user.Disabled,
      };
    }
  }
}
