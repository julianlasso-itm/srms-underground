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
  public sealed class DeleteCityUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ICityRepository<TEntity> cityRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteCityCommand,
      DeleteCityApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ICityRepository<TEntity> _cityRepository = cityRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCityDeleted}";

    public override async Task<Result<DeleteCityApplicationResponse>> Handle(
      DeleteCityCommand request
    )
    {
      var dataDeleteCity = MapToRequestForDomain(request);
      var city = AggregateRoot.DeleteCity(dataDeleteCity);

      if (city.IsFailure)
      {
        return Response<DeleteCityApplicationResponse>.Failure(
          city.Message,
          city.Code,
          city.Details
        );
      }
      var response = MapToResponse(city.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<DeleteCityApplicationResponse>.Success(response);
    }

    private static DeleteCityDomainRequest MapToRequestForDomain(DeleteCityCommand request)
    {
      return new DeleteCityDomainRequest { CityId = request.CityId };
    }

    private static DeleteCityApplicationResponse MapToResponse(DeleteCityDomainResponse city)
    {
      return new DeleteCityApplicationResponse { CityId = city.CityId };
    }

    private async Task<TEntity> Persistence(DeleteCityApplicationResponse response)
    {
      return await _cityRepository.DeleteAsync(Guid.Parse(response.CityId));
    }
  }
}
