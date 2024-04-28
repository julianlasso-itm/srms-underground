namespace Profiles.Domain.Aggregates.Dto.Requests;

public class UpdateCityDomainRequest
{
    public required string CityId { get; init; }
    public string? ProvinceId { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
}
