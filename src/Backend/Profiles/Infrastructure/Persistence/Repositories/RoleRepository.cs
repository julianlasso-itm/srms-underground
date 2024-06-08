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

    public async Task<RoleModel> UpdateAsync(Guid id, UpdateRoleApplicationResponse entity)
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
            RolePerSkillId = Guid.NewGuid(),
            RoleId = role.RoleId,
            SkillId = Guid.Parse(skill),
          })
          .ToList();
      }
      var data = await GetByIdAsync(role.RoleId);
      if (Context.Entry(data).Collection(role => role.RolePerSkills).IsLoaded == false)
      {
        Context.Entry(data).Collection(role => role.RolePerSkills).Load();
        _ = data.RolePerSkills.Select(rolePerSkill => Context.Remove(rolePerSkill));
      }
      return await UpdateAsync(id, role);
    }

    public new async Task<RoleModel> DeleteAsync(Guid id)
    {
      var data = await GetByIdAsync(id);
      if (Context.Entry(data).Collection(role => role.RolePerSkills).IsLoaded == false)
      {
        Context.Entry(data).Collection(role => role.RolePerSkills).Load();
        var info = data.RolePerSkills.Select(rolePerSkill =>
        {
          rolePerSkill.DeletedAt = DateTime.UtcNow;
          var info = Context.Update(rolePerSkill);
          return Task.CompletedTask;
        });
        await Task.WhenAll(info);
      }
      return await base.DeleteAsync(id);
    }

    public new async Task<IEnumerable<RoleModel>> GetWithPaginationAsync(
      int page,
      int limit,
      string? sort = null,
      string order = "asc",
      string? filter = null,
      string? filterBy = null
    )
    {
      var data = await base.GetWithPaginationAsync(page, limit, sort, order, filter, filterBy);
      if (data.Count() > 0)
      {
        var info = data.Select(role =>
        {
          if (Context.Entry(role).Collection(role => role.RolePerSkills).IsLoaded == false)
          {
            Context.Entry(role).Collection(role => role.RolePerSkills).Load();
          }

          if (Context.Entry(role).Collection(role => role.RolePerSkills).IsLoaded == true)
          {
            var info = role.RolePerSkills.Select(rolePerSkill =>
            {
              if (
                Context.Entry(rolePerSkill).Reference(rolePerSkill => rolePerSkill.Skill).IsLoaded
                == false
              )
              {
                Context.Entry(rolePerSkill).Reference(rolePerSkill => rolePerSkill.Skill).Load();
              }
              return Task.CompletedTask;
            });
            return Task.WhenAll(info);
          }

          return Task.CompletedTask;
        });
        await Task.WhenAll(info);
      }
      return data;
    }
  }
}
