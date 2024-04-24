using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository<Skill>
    {
        public SkillRepository(DbContext context) : base(context)
        {
        }

        public Task<Skill> AddAsync(RegisterSkillApplicationResponse entity)
        {
            var skill = new Skill
            {
                SkillId = Guid.Parse(entity.SkillId),
                Name = entity.Name,
                Disabled = entity.Disabled,
            };
            return AddAsync(skill);
        }
    }
}
