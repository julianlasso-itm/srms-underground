namespace Profiles.Domain.Aggregates.Dto.Requests;

public class RegisterProvinceDomainRequest
{
    public required string CountryId { get; init; }
    public required string Name { get; init; }
}
