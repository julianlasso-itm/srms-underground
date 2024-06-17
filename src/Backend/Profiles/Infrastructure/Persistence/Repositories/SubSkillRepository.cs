using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class SubSkillRepository(ApplicationDbContext context)
    : BaseRepository<SubSkillModel>(context),
      ISubSkillRepository<SubSkillModel>
  {
    public Task<SubSkillModel> AddAsync(RegisterSubSkillApplicationResponse entity)
    {
      var skill = new SubSkillModel
      {
        SubSkillId = Guid.Parse(entity.SubSkillId),
        SkillId = Guid.Parse(entity.SkillId),
        Name = entity.Name,
        Disabled = entity.Disabled,
      };
      return AddAsync(skill);
    }

    public Task<SubSkillModel> UpdateAsync(Guid id, UpdateSubSkillApplicationResponse entity)
    {
      var skill = new SubSkillModel { SubSkillId = id };
      if (entity.SkillId != null)
      {
        skill.SkillId = Guid.Parse(entity.SkillId);
      }
      if (entity.Name != null)
      {
        skill.Name = entity.Name;
      }
      if (entity.Disabled != null)
      {
        skill.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, skill);
    }
  }
}
