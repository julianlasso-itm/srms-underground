using AccessControl.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Infrastructure.Persistence;

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
            }
        };

        modelBuilder.Entity<RoleModel>().HasData(roles);
    }
}
