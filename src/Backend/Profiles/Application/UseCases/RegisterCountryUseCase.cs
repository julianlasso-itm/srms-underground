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
  public sealed class RegisterCountryUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ICountryRepository<TEntity> countryRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterCountryCommand,
      RegisterCountryApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ICountryRepository<TEntity> _countryRepository = countryRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCountryRegistered}";

    public override async Task<Result<RegisterCountryApplicationResponse>> Handle(
      RegisterCountryCommand request
    )
    {
      var newCountry = MapToRequestForDomain(request);
      var country = AggregateRoot.RegisterCountry(newCountry);

      if (country.IsFailure)
      {
        return Response<RegisterCountryApplicationResponse>.Failure(
          country.Message,
          country.Code,
          country.Details
        );
      }

      var data = MapToResponse(country.Data);
      _ = await Persistence(data);
      EmitEvent(Channel, JsonSerializer.Serialize(data));

      return Response<RegisterCountryApplicationResponse>.Success(data);
    }

    private static RegisterCountryDomainRequest MapToRequestForDomain(
      RegisterCountryCommand request
    )
    {
      return new RegisterCountryDomainRequest { Name = request.Name };
    }

    private static RegisterCountryApplicationResponse MapToResponse(
      RegisterCountryDomainResponse country
    )
    {
      return new RegisterCountryApplicationResponse
      {
        CountryId = country.CountryId,
        Name = country.Name,
        Disabled = country.Disabled,
      };
    }

    private async Task<TEntity> Persistence(RegisterCountryApplicationResponse response)
    {
      return await _countryRepository.AddAsync(response);
    }
  }
}
