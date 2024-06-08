using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsSkills
  {
    private static Guid CSharpSkillId = Guid.Parse("6098473e-8156-4328-a5bc-ef7f5af422de");
    private static Guid JavaSkillId = Guid.Parse("51373385-dce2-458c-a06b-9b20625b7702");
    private static Guid PythonSkillId = Guid.Parse("b2d2b1b0-c634-4a22-953e-45227a9af902");
    private static Guid JavaScriptSkillId = Guid.Parse("51137603-5df7-4d2d-8f30-799ef5a7dc12");
    private static Guid HtmlSkillId = Guid.Parse("10a818a6-b3df-41de-a69a-b451380343e5");
    private static Guid CssSkillId = Guid.Parse("0b3c088e-7185-4af6-94e5-bf11e29ce628");
    private static Guid SqlSkillId = Guid.Parse("76a48392-0e58-496a-ae78-562df47896b7");
    private static Guid NoSqlMongoDbSkillId = Guid.Parse("60537445-cb83-45d0-8c80-bf7368bc90c9");
    private static Guid AngularSkillId = Guid.Parse("f1ffa467-0220-487c-8afe-66ca42328365");
    private static Guid ReactSkillId = Guid.Parse("81d1012f-7b0a-421f-86b9-4d47ad266574");
    private static Guid NodeJsSkillId = Guid.Parse("0d63d379-f630-4064-bc9b-70bde09d3801");
    private static Guid SpringBootSkillId = Guid.Parse("b4cdcd4c-2ff3-457b-badf-782a89e0ad9b");

    public static void SeedSkills(ModelBuilder modelBuilder)
    {
      var skills = new List<SkillModel>
      {
        new()
        {
          SkillId = CSharpSkillId,
          Name = "C#",
          Disabled = false,
        },
        new()
        {
          SkillId = JavaSkillId,
          Name = "Java",
          Disabled = false,
        },
        new()
        {
          SkillId = PythonSkillId,
          Name = "Python",
          Disabled = false,
        },
        new()
        {
          SkillId = JavaScriptSkillId,
          Name = "JavaScript",
          Disabled = false,
        },
        new()
        {
          SkillId = HtmlSkillId,
          Name = "HTML",
          Disabled = false,
        },
        new()
        {
          SkillId = CssSkillId,
          Name = "CSS",
          Disabled = false,
        },
        new()
        {
          SkillId = SqlSkillId,
          Name = "SQL",
          Disabled = false,
        },
        new()
        {
          SkillId = NoSqlMongoDbSkillId,
          Name = "NoSQL - MongoDB",
          Disabled = false,
        },
        new()
        {
          SkillId = AngularSkillId,
          Name = "Angular",
          Disabled = false,
        },
        new()
        {
          SkillId = ReactSkillId,
          Name = "React",
          Disabled = false,
        },
        new()
        {
          SkillId = NodeJsSkillId,
          Name = "NodeJS",
          Disabled = false,
        },
        new()
        {
          SkillId = SpringBootSkillId,
          Name = "Spring Boot",
          Disabled = false,
        },
      };
      modelBuilder.Entity<SkillModel>().HasData(skills);
    }
  }
}
