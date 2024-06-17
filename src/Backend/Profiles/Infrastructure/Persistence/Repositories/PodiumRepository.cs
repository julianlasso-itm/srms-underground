using Profiles.Application.Repositories;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class PodiumRepository(ApplicationDbContext context)
    : BaseRepository<PodiumModel>(context),
      IPodiumRepository<PodiumModel> { }
}
