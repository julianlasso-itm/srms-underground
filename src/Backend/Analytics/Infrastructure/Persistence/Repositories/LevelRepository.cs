using Microsoft.EntityFrameworkCore;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Analytics.Infrastructure.Persistence.Repositories
{
    public class LevelRepository : BaseRepository<Level>, ILevelRepository<Level>
    {
        public LevelRepository(DbContext context) : base(context)
        {
        }

        public Task<Level> AddAsync(RegisterLevelApplicationResponse entity)
        {
            var level = new Level
            {
                LevelId = Guid.Parse(entity.LevelId),
                Name = entity.Name,
                Disabled = entity.Disabled,
            };
            return AddAsync(level);
        }

        public Task<Level> UpdateAsync(Guid id, UpdateLevelApplicationResponse entity)
        {
            var level = new Level { LevelId = id };
            if (entity.Name != null)
            {
                level.Name = entity.Name;
            }
            if (entity.Disabled != null)
            {
                level.Disabled = (bool)entity.Disabled;
            }
            return UpdateAsync(id, level);
        }
    }
}
