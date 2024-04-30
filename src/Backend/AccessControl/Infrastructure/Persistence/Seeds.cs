using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence
{
  public class Seeds
  {
    public static void SeedRoles(ModelBuilder modelBuilder)
    {
      var roles = new List<RoleModel>
      {
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Admin",
          Description = "Admin role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "User",
          Description = "User role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Guest",
          Description = "Guest role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "SuperAdmin",
          Description = "SuperAdmin role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Moderator",
          Description = "Moderator role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Editor",
          Description = "Editor role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Author",
          Description = "Author role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Contributor",
          Description = "Contributor role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Subscriber",
          Description = "Subscriber role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Member",
          Description = "Member role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Customer",
          Description = "Customer role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Client",
          Description = "Client role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Viewer",
          Description = "Viewer role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Tester",
          Description = "Tester role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = Guid.NewGuid(),
          Name = "Developer",
          Description = "Developer role",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
      };

      modelBuilder.Entity<RoleModel>().HasData(roles);
    }
  }
}
