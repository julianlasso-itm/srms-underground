using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsRolesPerSkills
  {
    private static Guid FullStackDeveloperRoleId = Guid.Parse(
      "359edb6c-cfdf-4a5c-9cd7-f07418f4719c"
    );
    private static Guid BackEndDeveloperRoleId = Guid.Parse("9186211b-adf4-4b18-bfe2-4516f5cdbb1c");
    private static Guid FrontEndDeveloperRoleId = Guid.Parse(
      "a4fa468c-8837-48a1-b5fd-b21354eb0eb4"
    );

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

    public static void SeedRolesPerSkills(ModelBuilder modelBuilder)
    {
      var rolesPerSkills = new List<RolePerSkillModel>
      {
        // Full Stack Developer (C#, Angular)
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FullStackDeveloperRoleId,
          SkillId = CSharpSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FullStackDeveloperRoleId,
          SkillId = AngularSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FullStackDeveloperRoleId,
          SkillId = HtmlSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FullStackDeveloperRoleId,
          SkillId = CssSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FullStackDeveloperRoleId,
          SkillId = SqlSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FullStackDeveloperRoleId,
          SkillId = NoSqlMongoDbSkillId,
        },
        // Back-end Developer (Java, Python)
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = BackEndDeveloperRoleId,
          SkillId = JavaSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = BackEndDeveloperRoleId,
          SkillId = SpringBootSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = BackEndDeveloperRoleId,
          SkillId = PythonSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = BackEndDeveloperRoleId,
          SkillId = NoSqlMongoDbSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = BackEndDeveloperRoleId,
          SkillId = SqlSkillId,
        },
        // Front-end Developer (React, Angular)
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FrontEndDeveloperRoleId,
          SkillId = ReactSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FrontEndDeveloperRoleId,
          SkillId = AngularSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FrontEndDeveloperRoleId,
          SkillId = HtmlSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FrontEndDeveloperRoleId,
          SkillId = CssSkillId,
        },
        new()
        {
          RolePerSkillId = Guid.NewGuid(),
          RoleId = FrontEndDeveloperRoleId,
          SkillId = JavaScriptSkillId,
        },
      };
      modelBuilder.Entity<RolePerSkillModel>().HasData(rolesPerSkills);
    }
  }
}
