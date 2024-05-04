using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class LevelRepository : BaseRepository<LevelModel>, ILevelRepository<LevelModel>
  {
    public LevelRepository(ApplicationDbContext context)
      : base(context) { }

    public Task<LevelModel> AddAsync(RegisterLevelApplicationResponse entity)
    {
      var level = new LevelModel
      {
        LevelId = Guid.Parse(entity.LevelId),
        Name = entity.Name,
        Description = entity.Description,
        Disabled = entity.Disabled,
        CreatedAt = DateTime.UtcNow
      };
      return AddAsync(level);
    }

    public Task<LevelModel> UpdateAsync(Guid id, UpdateLevelApplicationResponse entity)
    {
      var level = new LevelModel { LevelId = id };
      if (entity.Name != null)
      {
        level.Name = entity.Name;
      }
      if (entity.Description != null)
      {
        level.Description = entity.Description;
      }
      if (entity.Disabled != null)
      {
        level.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, level);
    }
  }
}
