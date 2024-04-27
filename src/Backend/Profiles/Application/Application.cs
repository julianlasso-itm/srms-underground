using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Application.UseCases;
using Profiles.Domain.Aggregates.Interfaces;

namespace Profiles.Application;

public class Application<TCountryEntity, TProvinceEntity, TCityEntity, TRoleEntity>
    where TCountryEntity : class
    where TProvinceEntity : class
    where TCityEntity : class
    where TRoleEntity : class
{
    public required IPersonnelAggregateRoot AggregateRoot { get; init; }

    private readonly ICountryRepository<TCountryEntity> _countryRepository;
    private readonly IProvinceRepository<TProvinceEntity> _provinceRepository;
    private readonly ICityRepository<TCityEntity> _cityRepository;
    private readonly IRoleRepository<TRoleEntity> _roleRepository;

    public Application(
        ICountryRepository<TCountryEntity> countryRepository,
        IProvinceRepository<TProvinceEntity> provinceRepository,
        ICityRepository<TCityEntity> cityRepository,
        IRoleRepository<TRoleEntity> roleRepository
    )
    {
        _countryRepository = countryRepository;
        _provinceRepository = provinceRepository;
        _cityRepository = cityRepository;
        _roleRepository = roleRepository;
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

    public Task<RegisterRoleApplicationResponse> RegisterRole(RegisterRoleCommand request)
    {
        var useCase = new RegisterRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateRoleApplicationResponse> UpdateRole(UpdateRoleCommand request)
    {
        var useCase = new UpdateRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteRoleApplicationResponse> DeleteRole(DeleteRoleCommand request)
    {
        var useCase = new DeleteRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<GetRolesApplicationResponse<TRoleEntity>> GetRoles(GetRolesCommand request)
    {
        var useCase = new GetRolesUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }
}
