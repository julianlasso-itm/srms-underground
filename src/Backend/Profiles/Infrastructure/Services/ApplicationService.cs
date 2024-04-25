using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace Profiles.Infrastructure.Services;

internal class ApplicationService
{
    private readonly Application<CountryModel, ProvinceModel, CityModel> _application;

    public ApplicationService(
        SharedEventHandler eventHandler,
        ICountryRepository<CountryModel> countryRepository,
        IProvinceRepository<ProvinceModel> provinceRepository,
        ICityRepository<CityModel> cityRepository
    )
    {
        _application = new Application<CountryModel, ProvinceModel, CityModel>(
            countryRepository,
            provinceRepository,
            cityRepository
        )
        {
            AggregateRoot = new PersonnelAggregateRoot(eventHandler)
        };
    }

    public Application<CountryModel, ProvinceModel, CityModel> GetApplication()
    {
        return _application;
    }
}
