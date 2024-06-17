using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace QueryBank.Infrastructure.Persistence.Repositories
{
  public class SkillRepository(ApplicationDbContext context)
    : BaseRepository<SkillModel>(context),
      ISkillRepository<SkillModel>
  {
    public Task<SkillModel> AddAsync(RegisterSkillApplicationResponse entity)
    {
      var skill = new SkillModel
      {
        SkillId = Guid.Parse(entity.SkillId),
        Name = entity.Name,
        Disabled = entity.Disabled,
      };
      return AddAsync(skill);
    }

    public Task<SkillModel> UpdateAsync(Guid id, UpdateSkillApplicationResponse entity)
    {
      var skill = new SkillModel { SkillId = id };
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
