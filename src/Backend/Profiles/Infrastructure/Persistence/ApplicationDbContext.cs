using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<RoleModel> Roles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}
