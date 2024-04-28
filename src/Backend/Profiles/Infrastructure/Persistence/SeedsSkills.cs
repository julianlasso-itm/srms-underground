using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence;

public class SeedsSkills
{
    public static void SeedSkills(ModelBuilder modelBuilder)
    {
        var skills = new List<SkillModel>
        {
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "C#",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "Java",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "Python",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "JavaScript",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "TypeScript",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "HTML",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "CSS",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "SQL",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "NoSQL",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "Angular",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "React",
                Disabled = false,
                CreatedAt = DateTime.UtcNow,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "Vue",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "Node.js",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "Spring Boot",
                Disabled = false,
            },
            new()
            {
                SkillId = Guid.NewGuid(),
                Name = "Hibernate",
                Disabled = false,
            },
        };
        modelBuilder.Entity<SkillModel>().HasData(skills);
    }
}
