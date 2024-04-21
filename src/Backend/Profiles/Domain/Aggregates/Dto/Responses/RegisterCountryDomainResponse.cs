namespace Profiles.Domain.Aggregates.Dto.Responses;

public class RegisterCountryDomainResponse
{
    public required string CountryId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
}
