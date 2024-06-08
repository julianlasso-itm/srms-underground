using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class AssessmentRepository : BaseRepository<AssessmentModel>, IAssessmentRepository<AssessmentModel>
  {
    public AssessmentRepository(ApplicationDbContext context)
      : base(context) { }

    public Task<AssessmentModel> AddAsync(RegisterAssessmentApplicationResponse entity)
    {
      var Assessment = new AssessmentModel
      {
        AssessmentId = Guid.Parse(entity.AssessmentId),
        ProfessionalId = Guid.Parse(entity.ProfessionalId),
        RoleId = Guid.Parse(entity.RoleId),
        SquadId = Guid.Parse(entity.SquadId),
      };
      return AddAsync(Assessment);
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
