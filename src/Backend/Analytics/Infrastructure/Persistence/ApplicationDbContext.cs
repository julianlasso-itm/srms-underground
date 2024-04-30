using Analytics.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Analytics.Infrastructure.Persistence
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<LevelModel> Level { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      Seeds.SeedLevels(modelBuilder);
    }
  }
}
