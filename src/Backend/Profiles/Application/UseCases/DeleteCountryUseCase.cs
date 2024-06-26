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
using Shared.Common.Bases;

namespace Profiles.Application.UseCases
{
  public sealed class DeleteCountryUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ICountryRepository<TEntity> countryRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteCountryCommand,
      DeleteCountryApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ICountryRepository<TEntity> _countryRepository = countryRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCountryDeleted}";

    public override async Task<Result<DeleteCountryApplicationResponse>> Handle(
      DeleteCountryCommand request
    )
    {
      var dataDeleteCountry = MapToRequestForDomain(request);
      var country = AggregateRoot.DeleteCountry(dataDeleteCountry);

      if (country.IsFailure)
      {
        return Response<DeleteCountryApplicationResponse>.Failure(
          country.Message,
          country.Code,
          country.Details
        );
      }

      var response = MapToResponse(country.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<DeleteCountryApplicationResponse>.Success(response);
    }

    private static DeleteCountryDomainRequest MapToRequestForDomain(DeleteCountryCommand request)
    {
      return new DeleteCountryDomainRequest { CountryId = request.CountryId };
    }

    private static DeleteCountryApplicationResponse MapToResponse(
      DeleteCountryDomainResponse country
    )
    {
      return new DeleteCountryApplicationResponse { CountryId = country.CountryId };
    }

    private async Task<TEntity> Persistence(DeleteCountryApplicationResponse response)
    {
      return await _countryRepository.DeleteAsync(Guid.Parse(response.CountryId));
    }
  }
}
