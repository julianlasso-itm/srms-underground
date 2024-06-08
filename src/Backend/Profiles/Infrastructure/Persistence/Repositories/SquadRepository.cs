using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class SquadRepository : BaseRepository<SquadModel>, ISquadRepository<SquadModel>
  {
    public SquadRepository(ApplicationDbContext context)
      : base(context) { }

    public Task<SquadModel> AddAsync(RegisterSquadApplicationResponse entity)
    {
      var Squad = new SquadModel
      {
        SquadId = Guid.Parse(entity.SquadId),
        Name = entity.Name,
        Disabled = entity.Disabled,
      };
      return AddAsync(Squad);
    }

    public Task<SquadModel> UpdateAsync(Guid id, UpdateSquadApplicationResponse entity)
    {
      var Squad = new SquadModel { SquadId = id };
      if (entity.Name != null)
      {
        Squad.Name = entity.Name;
      }
      if (entity.Disabled != null)
      {
        Squad.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, Squad);
    }
  }
}
