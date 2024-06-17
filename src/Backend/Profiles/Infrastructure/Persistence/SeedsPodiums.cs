using Microsoft.EntityFrameworkCore;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Persistence
{
  public class SeedsPodiums
  {
    public static void SeedPodiums(ModelBuilder modelBuilder)
    {
      var podiums = new List<PodiumModel>
      {
        new()
        {
          PodiumId = Guid.NewGuid(),
          Name = "Juan Perez",
          Email = "juan.perez@gmail.com",
          Photo =
            "https://orderszulu2024.blob.core.windows.net/users/SRMS-47a38449-7ffe-4e80-8067-b1684b02aaaf.webp",
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          PodiumId = Guid.NewGuid(),
          Name = "Alicia Ruiz",
          Email = "aliciaruis@gmail.com",
          Photo =
            "https://orderszulu2024.blob.core.windows.net/users/SRMS-6bb83a6f-f149-4be2-9d4d-aa48f2cd019e.webp",
          CreatedAt = DateTime.UtcNow,
        },
        new()
        {
          PodiumId = Guid.NewGuid(),
          Name = "Diego Gómez",
          Email = "diegogomez@gmail.com",
          Photo =
            "https://orderszulu2024.blob.core.windows.net/users/SRMS-aa8a6ecf-b17a-46a1-b821-43a0f39072c6.webp",
          CreatedAt = DateTime.UtcNow,
        },
      };

      modelBuilder.Entity<PodiumModel>().HasData(podiums);
    }
  }
}
