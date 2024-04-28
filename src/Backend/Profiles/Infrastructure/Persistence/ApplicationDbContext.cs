﻿using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Professional> Professionals { get; set; }

    public DbSet<Skill> Skills { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Professional>().HasIndex(c => new { c.Email, c.DeletedAt }).IsUnique();
        modelBuilder.Entity<Skill>().HasIndex(c => new { c.Name, c.DeletedAt }).IsUnique();
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
