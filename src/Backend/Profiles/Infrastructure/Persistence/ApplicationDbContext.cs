using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
  {
    public DbSet<CountryModel> Country { get; set; }
    public DbSet<ProvinceModel> Province { get; set; }
    public DbSet<CityModel> City { get; set; }
    public DbSet<RoleModel> Roles { get; set; }
    public DbSet<ProfessionalModel> Professionals { get; set; }
    public DbSet<SkillModel> Skills { get; set; }
    public DbSet<LevelModel> Levels { get; set; }
    public DbSet<SubSkillModel> SubSkills { get; set; }
    public DbSet<SquadModel> Squads { get; set; }
    public DbSet<AssessmentModel> Assessments { get; set; }
    public DbSet<RolePerSkillModel> RolePerSkills { get; set; }
    public DbSet<ResultModel> Results { get; set; }
    public DbSet<PodiumModel> Podium { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      SeedsPlaces.SeedCountries(modelBuilder);
      SeedsPlaces.SeedProvinces(modelBuilder);
      SeedsPlaces.SeedCities(modelBuilder);
      SeedsRoles.SeedRoles(modelBuilder);
      SeedsSkills.SeedSkills(modelBuilder);
      SeedsSubSkills.SeedSubSkills(modelBuilder);
      SeedsRolesPerSkills.SeedRolesPerSkills(modelBuilder);
      SeedsProfessionals.SeedProfessionals(modelBuilder);
      SeedsPodiums.SeedPodiums(modelBuilder);
    }
  }
}
