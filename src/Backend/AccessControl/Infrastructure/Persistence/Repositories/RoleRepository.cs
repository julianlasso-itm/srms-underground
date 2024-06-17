using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace AccessControl.Infrastructure.Persistence.Repositories
{
  public class RoleRepository(ApplicationDbContext context)
    : BaseRepository<RoleModel>(context),
      IRoleRepository<RoleModel>
  {
    public Task<RoleModel> AddAsync(RegisterRoleApplicationResponse entity)
    {
      var role = new RoleModel
      {
        RoleId = Guid.Parse(entity.RoleId),
        Name = entity.Name,
        Description = entity.Description,
        Disabled = entity.Disabled,
        CreatedAt = DateTime.UtcNow
      };
      return AddAsync(role);
    }

    public Task<RoleModel> UpdateAsync(Guid id, UpdateRoleApplicationResponse entity)
    {
      var role = new RoleModel { RoleId = id };
      if (entity.Name != null)
      {
        role.Name = entity.Name;
      }
      if (entity.Description != null)
      {
        role.Description = entity.Description;
      }
      if (entity.Disabled != null)
      {
        role.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, role);
    }
  }
}
