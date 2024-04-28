using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence;

public class SeedsRoles
{
    public static void SeedRoles(ModelBuilder modelBuilder)
    {
        var roles = new List<RoleModel>
        {
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Developer",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Designer",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Manager",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "QA",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "DevOps",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Data Scientist",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "UX/UI Designer",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Product Owner",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Scrum Master",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Architect",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Lead Developer",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                RoleId = Guid.NewGuid(),
                Name = "Lead Designer",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
        };

        modelBuilder.Entity<RoleModel>().HasData(roles);
    }
}
