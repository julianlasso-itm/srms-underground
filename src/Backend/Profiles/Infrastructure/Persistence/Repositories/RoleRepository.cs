using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class RoleRepository : BaseRepository<RoleModel>, IRoleRepository<RoleModel>
  {
    public RoleRepository(DbContext context)
      : base(context) { }

    public Task<RoleModel> AddAsync(RegisterRoleApplicationResponse entity)
    {
      var role = new RoleModel
      {
        RoleId = Guid.Parse(entity.RoleId),
        Name = entity.Name,
        Description = entity.Description,
        Disabled = entity.Disabled,
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
      if (entity.Disabled != null)
      {
        role.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, role);
    }
  }
}
