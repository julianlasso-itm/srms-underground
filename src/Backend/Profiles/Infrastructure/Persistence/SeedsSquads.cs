using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsSquads
  {
    public static void SeedSquads(ModelBuilder modelBuilder)
    {
      var podiums = new List<SquadModel>
      {
        new()
        {
          SquadId = Guid.NewGuid(),
          Name = "Titanium",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          SquadId = Guid.NewGuid(),
          Name = "Platinum",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          SquadId = Guid.NewGuid(),
          Name = "Temporis",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          SquadId = Guid.NewGuid(),
          Name = "Aurum",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          SquadId = Guid.NewGuid(),
          Name = "Ferrum",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
      };

      modelBuilder.Entity<SquadModel>().HasData(podiums);
    }
  }
}
