using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsRoles
  {
    private static readonly Guid FullStackDeveloperRoleId = Guid.Parse(
      "359edb6c-cfdf-4a5c-9cd7-f07418f4719c"
    );
    private static readonly Guid BackEndDeveloperRoleId = Guid.Parse(
      "9186211b-adf4-4b18-bfe2-4516f5cdbb1c"
    );
    private static readonly Guid FrontEndDeveloperRoleId = Guid.Parse(
      "a4fa468c-8837-48a1-b5fd-b21354eb0eb4"
    );

    public static void SeedRoles(ModelBuilder modelBuilder)
    {
      var roles = new List<RoleModel>
      {
        new()
        {
          RoleId = FullStackDeveloperRoleId,
          Name = "Full Stack Developer (C#, Angular)",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = BackEndDeveloperRoleId,
          Name = "Back-end Developer (Java, Python)",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          RoleId = FrontEndDeveloperRoleId,
          Name = "Front-end Developer (React, Angular)",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
      };

      modelBuilder.Entity<RoleModel>().HasData(roles);
    }
  }
}
