using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
  {
    public DbSet<UserModel> User { get; set; }
    public DbSet<RoleModel> Role { get; set; }
    public DbSet<UserPerRoleModel> UserPerRole { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      Seeds.SeedRoles(modelBuilder);
    }
  }
}
