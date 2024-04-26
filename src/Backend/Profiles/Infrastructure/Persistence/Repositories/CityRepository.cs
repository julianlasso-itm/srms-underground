using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories;

public class CityRepository : BaseRepository<CityModel>, ICityRepository<CityModel>
{
    public CityRepository(DbContext context)
        : base(context) { }

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
