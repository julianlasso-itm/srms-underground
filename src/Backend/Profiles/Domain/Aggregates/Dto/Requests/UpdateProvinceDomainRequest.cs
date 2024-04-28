namespace Profiles.Domain.Aggregates.Dto.Requests;

public class UpdateProvinceDomainRequest
{
    public required string ProvinceId { get; init; }
    public string? CountryId { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
}
