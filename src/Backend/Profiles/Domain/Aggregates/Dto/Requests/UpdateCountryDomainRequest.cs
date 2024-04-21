namespace Profiles.Domain.Aggregates.Dto.Requests;

public class UpdateCountryDomainRequest
{
    public required string CountryId { get; init; }
    public string? Name { get; init; }
}
