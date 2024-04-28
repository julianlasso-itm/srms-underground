using System.Text.Json;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases;

public sealed class RegisterCountryUseCase<TEntity>
    : BaseUseCase<
        RegisterCountryCommand,
        RegisterCountryApplicationResponse,
        IPersonnelAggregateRoot
    >
    where TEntity : class
{
    private readonly ICountryRepository<TEntity> _countryRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCountryRegistered}";

    public RegisterCountryUseCase(
        IPersonnelAggregateRoot aggregateRoot,
        ICountryRepository<TEntity> countryRepository
    )
        : base(aggregateRoot)
    {
        _countryRepository = countryRepository;
    }

    public override async Task<RegisterCountryApplicationResponse> Handle(
        RegisterCountryCommand request
    )
    {
        var newCountry = MapToRequestForDomain(request);
        var country = AggregateRoot.RegisterCountry(newCountry);
        var response = MapToResponse(country);
        _ = await Persistence(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
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
