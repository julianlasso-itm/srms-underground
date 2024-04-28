using Analytics.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Analytics.Infrastructure.Persistence;

public class Seeds
{
    public static void SeedLevels(ModelBuilder modelBuilder)
    {
        var levels = new List<LevelModel>
        {
            new()
            {
                LevelId = Guid.NewGuid(),
                Name = "Backend",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                LevelId = Guid.NewGuid(),
                Name = "Frontend",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                LevelId = Guid.NewGuid(),
                Name = "Fullstack",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            }
        };

        modelBuilder.Entity<LevelModel>().HasData(levels);
    }
}
