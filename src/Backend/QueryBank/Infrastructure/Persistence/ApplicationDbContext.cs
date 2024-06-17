using Microsoft.EntityFrameworkCore;
using QueryBank.Infrastructure.Persistence.Models;

namespace QueryBank.Infrastructure.Persistence
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
  {
    public DbSet<SkillModel> Skills { get; set; }
  }
}
