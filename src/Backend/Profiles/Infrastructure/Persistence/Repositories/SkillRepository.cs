﻿using Microsoft.EntityFrameworkCore;
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

        public Task<Skill> UpdateAsync(Guid id, UpdateSkillApplicationResponse entity)
        {
            var skill = new Skill { SkillId = id };
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