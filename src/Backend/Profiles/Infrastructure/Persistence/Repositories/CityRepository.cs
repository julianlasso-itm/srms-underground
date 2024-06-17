using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class CityRepository(ApplicationDbContext context)
    : BaseRepository<CityModel>(context),
      ICityRepository<CityModel>
  {
    public new async Task<IEnumerable<CityModel>> GetWithPaginationAsync(
      int page,
      int limit,
      string? sort = null,
      string order = "asc",
      string? filter = null,
      string? filterBy = null
    )
    {
      var data = await base.GetWithPaginationAsync(page, limit, sort, order, filter, filterBy);
      data.ToList()
        .ForEach(city =>
        {
          if (Context.Entry(city).Reference(c => c.Province).IsLoaded == false)
          {
            Context.Entry(city).Reference(c => c.Province).Load();
            if (Context.Entry(city.Province).Reference(p => p.Country).IsLoaded == false)
            {
              Context.Entry(city.Province).Reference(p => p.Country).Load();
            }
          }
        });
      return data;
    }

    public Task<CityModel> AddAsync(RegisterCityApplicationResponse entity)
    {
      var city = new CityModel
      {
        CityId = Guid.Parse(entity.CityId),
        Name = entity.Name,
        ProvinceId = Guid.Parse(entity.ProvinceId),
        Disabled = entity.Disabled,
      };
      return AddAsync(city);
    }

    public Task<CityModel> UpdateAsync(Guid id, UpdateCityApplicationResponse entity)
    {
      var city = new CityModel { CityId = id };
      if (entity.Name != null)
      {
        city.Name = entity.Name;
      }
      if (entity.ProvinceId != null)
      {
        city.ProvinceId = Guid.Parse(entity.ProvinceId);
      }
      if (entity.Disabled != null)
      {
        city.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, city);
    }
  }
}
