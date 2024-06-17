using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class CountryRepository(ApplicationDbContext context)
    : BaseRepository<CountryModel>(context),
      ICountryRepository<CountryModel>
  {
    public Task<CountryModel> AddAsync(RegisterCountryApplicationResponse entity)
    {
      var country = new CountryModel
      {
        CountryId = Guid.Parse(entity.CountryId),
        Name = entity.Name,
        Disabled = entity.Disabled,
      };
      return AddAsync(country);
    }

    public Task<CountryModel> UpdateAsync(Guid id, UpdateCountryApplicationResponse entity)
    {
      var country = new CountryModel { CountryId = id };
      if (entity.Name != null)
      {
        country.Name = entity.Name;
      }
      if (entity.Disabled != null)
      {
        country.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, country);
    }
  }
}
