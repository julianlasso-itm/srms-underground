using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
    public class ProfessionalRepository : BaseRepository<Professional>, IProfessionalRepository<Professional>
    {
        public ProfessionalRepository(DbContext context) : base(context)
        {
        }

        public Task<Professional> AddAsync(RegisterProfessionalApplicationResponse entity)
        {
            var professional = new Professional
            {
                ProfessionalId = Guid.Parse(entity.ProfessionalId),
                Name = entity.Name,
                Email = entity.Email,
                Disabled = entity.Disabled,
            };
            return AddAsync(professional);
        }

        public Task<Professional> UpdateAsync(Guid id, UpdateProfessionalApplicationResponse entity)
        {
            var professional = new Professional { ProfessionalId = id };
            if (entity.Name != null)
            {
                professional.Name = entity.Name;
            }
            if (entity.Disabled != null)
            {
                professional.Disabled = entity.Disabled;
            }
            return UpdateAsync(id, professional);
        }
    }
}
