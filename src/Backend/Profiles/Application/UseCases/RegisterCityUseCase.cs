using System.Text.Json;
using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public sealed class RegisterCityUseCase<TEntity>
    : BaseUseCase<
      RegisterCityCommand,
      RegisterCityApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly ICityRepository<TEntity> _cityRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCityRegistered}";

    public RegisterCityUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      ICityRepository<TEntity> cityRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _cityRepository = cityRepository;
    }

    public override async Task<RegisterCityApplicationResponse> Handle(RegisterCityCommand request)
    {
      var newCity = MapToRequestForDomain(request);
      var city = AggregateRoot.RegisterCity(newCity);
      var response = MapToResponse(city);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private static RegisterCityDomainRequest MapToRequestForDomain(RegisterCityCommand request)
    {
      return new RegisterCityDomainRequest { Name = request.Name, ProvinceId = request.ProvinceId };
    }

    private static RegisterCityApplicationResponse MapToResponse(RegisterCityDomainResponse city)
    {
      return new RegisterCityApplicationResponse
      {
        CityId = city.CityId,
        ProvinceId = city.ProvinceId,
        Name = city.Name,
        Disabled = city.Disabled,
      };
    }

    private async Task<TEntity> Persistence(RegisterCityApplicationResponse response)
    {
      return await _cityRepository.AddAsync(response);
    }
  }
}
