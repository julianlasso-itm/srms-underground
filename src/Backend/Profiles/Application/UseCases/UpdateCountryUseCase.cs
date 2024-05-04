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
  public sealed class UpdateCountryUseCase<TEntity>
    : BaseUseCase<
      UpdateCountryCommand,
      UpdateCountryApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly ICountryRepository<TEntity> _countryRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCountryUpdated}";

    public UpdateCountryUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      ICountryRepository<TEntity> countryRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _countryRepository = countryRepository;
    }

    public override async Task<UpdateCountryApplicationResponse> Handle(
      UpdateCountryCommand request
    )
    {
      var newCountry = MapToRequestForDomain(request);
      var country = AggregateRoot.UpdateCountry(newCountry);
      var response = MapToResponse(country);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private static UpdateCountryDomainRequest MapToRequestForDomain(UpdateCountryCommand request)
    {
      return new UpdateCountryDomainRequest
      {
        CountryId = request.CountryId,
        Name = request.Name,
        Disable = request.Disable,
      };
    }

    private static UpdateCountryApplicationResponse MapToResponse(
      UpdateCountryDomainResponse country
    )
    {
      return new UpdateCountryApplicationResponse
      {
        CountryId = country.CountryId,
        Name = country.Name,
        Disabled = country.Disabled,
      };
    }

    private async Task<TEntity> Persistence(UpdateCountryApplicationResponse response)
    {
      return await _countryRepository.UpdateAsync(Guid.Parse(response.CountryId), response);
    }
  }
}
