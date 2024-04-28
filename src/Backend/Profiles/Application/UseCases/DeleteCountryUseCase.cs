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

public sealed class DeleteCountryUseCase<TEntity>
    : BaseUseCase<DeleteCountryCommand, DeleteCountryApplicationResponse, IPersonnelAggregateRoot>
    where TEntity : class
{
    private readonly ICountryRepository<TEntity> _countryRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCountryDeleted}";

    public DeleteCountryUseCase(
        IPersonnelAggregateRoot aggregateRoot,
        ICountryRepository<TEntity> countryRepository
    )
        : base(aggregateRoot)
    {
        _countryRepository = countryRepository;
    }

    public override async Task<DeleteCountryApplicationResponse> Handle(
        DeleteCountryCommand request
    )
    {
        var dataDeleteCountry = MapToRequestForDomain(request);
        var country = AggregateRoot.DeleteCountry(dataDeleteCountry);
        var response = MapToResponse(country);
        _ = await Persistence(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
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
