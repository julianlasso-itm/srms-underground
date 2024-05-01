using Microsoft.EntityFrameworkCore;
using QueryBank.Infrastructure.Persistence.Models;

namespace QueryBank.Infrastructure.Persistence
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<SkillModel> Skills { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options) { }
  }
}
