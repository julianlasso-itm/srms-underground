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
using Shared.Common;

namespace Profiles.Application.UseCases
{
  public sealed class RegisterCityUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ICityRepository<TEntity> cityRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterCityCommand,
      RegisterCityApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ICityRepository<TEntity> _cityRepository = cityRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCityRegistered}";

    public override async Task<Result<RegisterCityApplicationResponse>> Handle(
      RegisterCityCommand request
    )
    {
      var newCity = MapToRequestForDomain(request);
      var city = AggregateRoot.RegisterCity(newCity);

      if (city.IsFailure)
      {
        return Response<RegisterCityApplicationResponse>.Failure(
          city.Message,
          city.Code,
          city.Details
        );
      }

      var response = MapToResponse(city.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<RegisterCityApplicationResponse>.Success(response);
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
