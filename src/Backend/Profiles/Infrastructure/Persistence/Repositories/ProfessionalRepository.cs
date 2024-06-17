using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class ProfessionalRepository(ApplicationDbContext context)
    : BaseRepository<ProfessionalModel>(context),
      IProfessionalRepository<ProfessionalModel>
  {
    public Task<ProfessionalModel> AddAsync(RegisterProfessionalApplicationResponse entity)
    {
      var professional = new ProfessionalModel
      {
        ProfessionalId = Guid.Parse(entity.ProfessionalId),
        Name = entity.Name,
        Email = entity.Email,
        Disabled = entity.Disabled,
      };
      return AddAsync(professional);
    }

    public Task<ProfessionalModel> UpdateAsync(
      Guid id,
      UpdateProfessionalApplicationResponse entity
    )
    {
      var professional = new ProfessionalModel { ProfessionalId = id };
      if (entity.Name != null)
      {
        professional.Name = entity.Name;
      }
      if (entity.Email != null)
      {
        professional.Email = entity.Email;
      }
      if (entity.Disabled != null)
      {
        professional.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, professional);
    }
  }
}
