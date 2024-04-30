using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsProfessionals
  {
    public static void SeedProfessionals(ModelBuilder modelBuilder)
    {
      var professionals = new List<ProfessionalModel>
      {
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Juan Pérez",
          Email = "juanperez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "María García",
          Email = "mariagarcia@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Pedro López",
          Email = "pedrolopez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Ana Sánchez",
          Email = "anasanchez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Carlos Rodríguez",
          Email = "carlosrodriguez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Isabel Martínez",
          Email = "isabelmartinez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Diego Gómez",
          Email = "diegogomez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Sandra Moreno",
          Email = "sandramoreno@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Andrés Fernández",
          Email = "andresfernandez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Laura González",
          Email = "lauragonzalez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Javier Muñoz",
          Email = "javiermunoz@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Patricia Blanco",
          Email = "patriciablanco@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "José Gutiérrez",
          Email = "josegutierrez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Alicia Ruiz",
          Email = "aliciaruis@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          ProfessionalId = Guid.NewGuid(),
          Name = "Luis Vázquez",
          Email = "luisvazquez@gmail.com",
          Disabled = false,
          CreatedAt = DateTime.UtcNow,
        },
      };

      modelBuilder.Entity<ProfessionalModel>().HasData(professionals);
    }
  }
}
