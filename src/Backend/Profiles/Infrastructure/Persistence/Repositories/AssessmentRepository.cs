using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class AssessmentRepository
    : BaseRepository<AssessmentModel>,
      IAssessmentRepository<AssessmentModel>
  {
    public AssessmentRepository(ApplicationDbContext context)
      : base(context) { }

    public async Task<AssessmentModel> AddAsync(RegisterAssessmentApplicationResponse entity)
    {
      var assessment = new AssessmentModel
      {
        AssessmentId = Guid.Parse(entity.AssessmentId),
        ProfessionalId = Guid.Parse(entity.ProfessionalId),
        RoleId = Guid.Parse(entity.RoleId),
        SquadId = Guid.Parse(entity.SquadId),
      };

      var role = new RoleModel { RoleId = assessment.RoleId };
      var roleEntry = Context.Entry(role);

      if (!roleEntry.Collection(r => r.RolePerSkills).IsLoaded)
      {
        await roleEntry.Collection(r => r.RolePerSkills).LoadAsync();
      }

      foreach (var rolePerSkill in role.RolePerSkills)
      {
        var skill = new SkillModel { SkillId = rolePerSkill.SkillId };
        var skillEntry = Context.Entry(skill);

        if (!skillEntry.Collection(s => s.SubSkills).IsLoaded)
        {
          await skillEntry.Collection(s => s.SubSkills).LoadAsync();
        }

        foreach (var subSkill in skill.SubSkills)
        {
          assessment.Results.Add(
            new ResultModel
            {
              ResultId = Guid.NewGuid(),
              AssessmentId = assessment.AssessmentId,
              SubSkillId = subSkill.SubSkillId,
              Result = 0,
              DateTime = DateTime.UtcNow,
            }
          );
        }
      }

      return await AddAsync(assessment);
    }

    public Task<AssessmentModel> UpdateAsync(Guid id, UpdateAssessmentApplicationResponse entity)
    {
      var Assessment = new AssessmentModel { AssessmentId = id };
      if (entity.ProfessionalId != null)
      {
        Assessment.ProfessionalId = Guid.Parse(entity.ProfessionalId);
      }
      if (entity.RoleId != null)
      {
        Assessment.RoleId = Guid.Parse(entity.RoleId);
      }
      if (entity.SquadId != null)
      {
        Assessment.SquadId = Guid.Parse(entity.SquadId);
      }
      return UpdateAsync(id, Assessment);
    }
  }
}
