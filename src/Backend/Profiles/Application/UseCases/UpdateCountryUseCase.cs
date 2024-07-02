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
  public sealed class UpdateCountryUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ICountryRepository<TEntity> countryRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateCountryCommand,
      UpdateCountryApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ICountryRepository<TEntity> _countryRepository = countryRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCountryUpdated}";

    public override async Task<Result<UpdateCountryApplicationResponse>> Handle(
      UpdateCountryCommand request
    )
    {
      var newCountry = MapToRequestForDomain(request);
      var country = AggregateRoot.UpdateCountry(newCountry);

      if (country.IsFailure)
      {
        return Response<UpdateCountryApplicationResponse>.Failure(
          country.Message,
          country.Code,
          country.Details
        );
      }

      var response = MapToResponse(country.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateCountryApplicationResponse>.Success(response);
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
