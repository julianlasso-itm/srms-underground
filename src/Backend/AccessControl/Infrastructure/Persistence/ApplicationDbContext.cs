using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<RoleModel> Role { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      Seeds.SeedRoles(modelBuilder);
    }
  }
}
