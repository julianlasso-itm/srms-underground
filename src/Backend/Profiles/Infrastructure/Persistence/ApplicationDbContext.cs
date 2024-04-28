using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<ProfessionalModel> Professionals { get; set; }

    public DbSet<SkillModel> Skills { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .Entity<ProfessionalModel>()
            .HasIndex(c => new { c.Email, c.DeletedAt })
            .IsUnique();
        modelBuilder.Entity<SkillModel>().HasIndex(c => new { c.Name, c.DeletedAt }).IsUnique();
        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());

        foreach (var relationship in relationships)
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
