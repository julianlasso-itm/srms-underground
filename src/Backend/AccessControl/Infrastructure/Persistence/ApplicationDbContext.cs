using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserModel> User { get; set; }
    public DbSet<RoleModel> Role { get; set; }
    public DbSet<UserPerRoleModel> UserPerRoles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserPerRoleModel>().HasKey(upr => new { upr.UserId, upr.RoleId });

        modelBuilder
            .Entity<UserPerRoleModel>()
            .HasOne(upr => upr.User)
            .WithMany(u => u.UserPerRoles)
            .HasForeignKey(upr => upr.UserId);

        modelBuilder
            .Entity<UserPerRoleModel>()
            .HasOne(upr => upr.Role)
            .WithMany(r => r.UserPerRoles)
            .HasForeignKey(upr => upr.RoleId);

        DisableCascadeDelete(modelBuilder);
    }

    private void DisableCascadeDelete(ModelBuilder modelBuilder)
    {
        foreach (
            var relationship in modelBuilder
                .Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())
        )
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
