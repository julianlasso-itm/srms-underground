using Microsoft.EntityFrameworkCore;
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
    private readonly DbContextOptions<ApplicationDbContext> _contextOptions;

    public AssessmentRepository(
      ApplicationDbContext context,
      DbContextOptions<ApplicationDbContext> contextOptions
    )
      : base(context)
    {
      _contextOptions = contextOptions;
    }

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

    public new async Task<IEnumerable<AssessmentModel>> GetWithPaginationAsync(
      int page,
      int limit,
      string? sort = null,
      string order = "asc",
      string? filter = null,
      string? filterBy = null
    )
    {
      var assessments = await base.GetWithPaginationAsync(
        page,
        limit,
        sort,
        order,
        filter,
        filterBy
      );

      if (assessments.Count() > 0)
      {
        var data = assessments.Select(assessment => LoadAssessmentReferencesAsync(assessment));
        await Task.WhenAll(data);
      }
      return assessments;
    }

    private async Task LoadAssessmentReferencesAsync(AssessmentModel assessment)
    {
      using (var newContext = new ApplicationDbContext(_contextOptions))
      {
        var assessmentEntry = newContext.Entry(assessment);
        if (!assessmentEntry.Reference(a => a.Professional).IsLoaded)
        {
          await assessmentEntry.Reference(a => a.Professional).LoadAsync();
        }
        if (!assessmentEntry.Reference(a => a.Role).IsLoaded)
        {
          await assessmentEntry.Reference(a => a.Role).LoadAsync();
        }
        if (!assessmentEntry.Reference(a => a.Squad).IsLoaded)
        {
          await assessmentEntry.Reference(a => a.Squad).LoadAsync();
        }
        var roleEntry = newContext.Entry(assessment.Role);
        if (!roleEntry.Collection(r => r.RolePerSkills).IsLoaded)
        {
          await roleEntry.Collection(r => r.RolePerSkills).LoadAsync();
        }
        foreach (var rolePerSkill in assessment.Role.RolePerSkills)
        {
          var rolePerSkillEntry = newContext.Entry(rolePerSkill);
          if (!rolePerSkillEntry.Reference(rps => rps.Skill).IsLoaded)
          {
            await rolePerSkillEntry.Reference(rps => rps.Skill).LoadAsync();
          }
          var skillEntry = newContext.Entry(rolePerSkill.Skill);
          if (!skillEntry.Collection(s => s.SubSkills).IsLoaded)
          {
            await skillEntry.Collection(s => s.SubSkills).LoadAsync();
          }
          foreach (var subSkill in rolePerSkill.Skill.SubSkills)
          {
            subSkill.Results = await newContext
              .Set<ResultModel>()
              .Where(r =>
                r.SubSkillId == subSkill.SubSkillId && r.AssessmentId == assessment.AssessmentId
              )
              .ToListAsync();
          }
        }
      }
    }
  }
}
