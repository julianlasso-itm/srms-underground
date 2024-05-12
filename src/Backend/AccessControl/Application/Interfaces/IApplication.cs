using AccessControl.Application.Commands;
using AccessControl.Application.Responses;

namespace AccessControl.Application.Interfaces
{
  public interface IApplication<TUserEntity, TRoleEntity>
    where TUserEntity : class
    where TRoleEntity : class
  {
    Task<RegisterUserApplicationResponse> RegisterUser(RegisterUserCommand request);
    Task<RegisterRoleApplicationResponse> RegisterRole(RegisterRoleCommand request);
    Task<UpdateRoleApplicationResponse> UpdateRole(UpdateRoleCommand request);
    Task<DeleteRoleApplicationResponse> DeleteRole(DeleteRoleCommand request);
    Task<GetRolesApplicationResponse<TRoleEntity>> GetRoles(GetRolesCommand request);
    Task<ActivationTokenApplicationResponse> ActivateToken(ActivateTokenCommand request);
  }
}
