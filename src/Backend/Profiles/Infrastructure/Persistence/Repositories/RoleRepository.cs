using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class RoleRepository : BaseRepository<RoleModel>, IRoleRepository<RoleModel>
  {
    public RoleRepository(ApplicationDbContext context)
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

      if (entity.Skills != null)
      {
        role.RolePerSkills = entity
          .Skills.Select(skill => new RolePerSkillModel
          {
            RolePerSkillId = Guid.NewGuid(),
            RoleId = role.RoleId,
            SkillId = Guid.Parse(skill),
          })
          .ToList();
      }

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
      if (entity.Skills != null)
      {
        role.RolePerSkills = entity
          .Skills.Select(skill => new RolePerSkillModel
          {
            RoleId = role.RoleId,
            SkillId = Guid.Parse(skill),
          })
          .ToList();
      }
      return UpdateAsync(id, role);
    }

    public new async Task<RoleModel> DeleteAsync(Guid id)
    {
      var data = await GetByIdAsync(id);
      Console.WriteLine(data.RolePerSkills.Count);
      return await base.DeleteAsync(id);
    }
  }
}
