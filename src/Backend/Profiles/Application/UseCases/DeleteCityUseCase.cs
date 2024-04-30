using System.Text.Json;
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
  public sealed class DeleteCityUseCase<TEntity>
    : BaseUseCase<DeleteCityCommand, DeleteCityApplicationResponse, IPersonnelAggregateRoot>
    where TEntity : class
  {
    private readonly ICityRepository<TEntity> _cityRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCityDeleted}";

    public DeleteCityUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      ICityRepository<TEntity> cityRepository
    )
      : base(aggregateRoot)
    {
      _cityRepository = cityRepository;
    }

    public override async Task<DeleteCityApplicationResponse> Handle(DeleteCityCommand request)
    {
      var dataDeleteCity = MapToRequestForDomain(request);
      var city = AggregateRoot.DeleteCity(dataDeleteCity);
      var response = MapToResponse(city);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
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
