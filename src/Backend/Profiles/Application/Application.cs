using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Application.UseCases;
using Profiles.Domain.Aggregates.Interfaces;

namespace Profiles.Application;

public class Application<TCountryEntity, TProvinceEntity, TCityEntity>
    where TCountryEntity : class
    where TProvinceEntity : class
    where TCityEntity : class
{
    public required IPersonnelAggregateRoot AggregateRoot { get; init; }

    private readonly ICountryRepository<TCountryEntity> _countryRepository;
    private readonly IProvinceRepository<TProvinceEntity> _provinceRepository;
    private readonly ICityRepository<TCityEntity> _cityRepository;

    public Application(
        ICountryRepository<TCountryEntity> countryRepository,
        IProvinceRepository<TProvinceEntity> provinceRepository,
        ICityRepository<TCityEntity> cityRepository
    )
    {
        _countryRepository = countryRepository;
        _provinceRepository = provinceRepository;
        _cityRepository = cityRepository;
    }

    public Task<GetCountriesApplicationResponse<TCountryEntity>> GetCountries(
        GetCountriesCommand request
    )
    {
        var useCase = new GetCountriesUseCase<TCountryEntity>(AggregateRoot, _countryRepository);
        return useCase.Handle(request);
    }

    public Task<RegisterCountryApplicationResponse> RegisterCountry(RegisterCountryCommand request)
    {
        var useCase = new RegisterCountryUseCase<TCountryEntity>(AggregateRoot, _countryRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateCountryApplicationResponse> UpdateCountry(UpdateCountryCommand request)
    {
        var useCase = new UpdateCountryUseCase<TCountryEntity>(AggregateRoot, _countryRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteCountryApplicationResponse> DeleteCountry(DeleteCountryCommand request)
    {
        var useCase = new DeleteCountryUseCase<TCountryEntity>(AggregateRoot, _countryRepository);
        return useCase.Handle(request);
    }

    public Task<GetProvincesApplicationResponse<TProvinceEntity>> GetProvinces(
        GetProvincesCommand request
    )
    {
        var useCase = new GetProvincesUseCase<TProvinceEntity>(AggregateRoot, _provinceRepository);
        return useCase.Handle(request);
    }

    public Task<RegisterProvinceApplicationResponse> RegisterProvince(
        RegisterProvinceCommand request
    )
    {
        var useCase = new RegisterProvinceUseCase<TProvinceEntity>(
            AggregateRoot,
            _provinceRepository
        );
        return useCase.Handle(request);
    }

    public Task<UpdateProvinceApplicationResponse> UpdateProvince(UpdateProvinceCommand request)
    {
        var useCase = new UpdateProvinceUseCase<TProvinceEntity>(
            AggregateRoot,
            _provinceRepository
        );
        return useCase.Handle(request);
    }

    public Task<DeleteProvinceApplicationResponse> DeleteProvince(DeleteProvinceCommand request)
    {
        var useCase = new DeleteProvinceUseCase<TProvinceEntity>(
            AggregateRoot,
            _provinceRepository
        );
        return useCase.Handle(request);
    }

    public Task<GetCitiesApplicationResponse<TCityEntity>> GetCities(GetCitiesCommand request)
    {
        var useCase = new GetCitiesUseCase<TCityEntity>(AggregateRoot, _cityRepository);
        return useCase.Handle(request);
    }

    public Task<RegisterCityApplicationResponse> RegisterCity(RegisterCityCommand request)
    {
        var useCase = new RegisterCityUseCase<TCityEntity>(AggregateRoot, _cityRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateCityApplicationResponse> UpdateCity(UpdateCityCommand request)
    {
        var useCase = new UpdateCityUseCase<TCityEntity>(AggregateRoot, _cityRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteCityApplicationResponse> DeleteCity(DeleteCityCommand request)
    {
        var useCase = new DeleteCityUseCase<TCityEntity>(AggregateRoot, _cityRepository);
        return useCase.Handle(request);
    }
}
