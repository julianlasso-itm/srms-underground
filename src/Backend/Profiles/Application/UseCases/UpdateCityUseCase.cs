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
  public sealed class UpdateCityUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ICityRepository<TEntity> cityRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateCityCommand,
      UpdateCityApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ICityRepository<TEntity> _cityRepository = cityRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCityUpdated}";

    public override async Task<Result<UpdateCityApplicationResponse>> Handle(
      UpdateCityCommand request
    )
    {
      var newCity = MapToRequestForDomain(request);
      var city = AggregateRoot.UpdateCity(newCity);

      if (city.IsFailure)
      {
        return Response<UpdateCityApplicationResponse>.Failure(
          city.Message,
          city.Code,
          city.Details
        );
      }

      var response = MapToResponse(city.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateCityApplicationResponse>.Success(response);
    }

    private static UpdateCityDomainRequest MapToRequestForDomain(UpdateCityCommand request)
    {
      return new UpdateCityDomainRequest
      {
        CityId = request.CityId,
        ProvinceId = request.ProvinceId,
        Name = request.Name,
        Disable = request.Disable,
      };
    }

    private static UpdateCityApplicationResponse MapToResponse(UpdateCityDomainResponse city)
    {
      return new UpdateCityApplicationResponse
      {
        CityId = city.CityId,
        ProvinceId = city.ProvinceId,
        Name = city.Name,
        Disabled = city.Disabled,
      };
    }

    private async Task<TEntity> Persistence(UpdateCityApplicationResponse response)
    {
      return await _cityRepository.UpdateAsync(Guid.Parse(response.CityId), response);
    }
  }
}
