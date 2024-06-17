using Analytics.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Analytics.Infrastructure.Persistence
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
  {
    public DbSet<LevelModel> Level { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      Seeds.SeedLevels(modelBuilder);
    }
  }
}
