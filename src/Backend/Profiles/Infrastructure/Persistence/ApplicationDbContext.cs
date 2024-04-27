using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<CountryModel> Country { get; set; }
    public DbSet<ProvinceModel> Province { get; set; }
    public DbSet<CityModel> City { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Seeds.SeedCountries(modelBuilder);
        Seeds.SeedProvinces(modelBuilder);
        Seeds.SeedCities(modelBuilder);
    }
}
