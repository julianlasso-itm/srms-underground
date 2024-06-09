using Profiles.Application.Repositories;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class PodiumRepository : BaseRepository<PodiumModel>, IPodiumRepository<PodiumModel>
  {
    public PodiumRepository(ApplicationDbContext context)
      : base(context) { }
  }
}
