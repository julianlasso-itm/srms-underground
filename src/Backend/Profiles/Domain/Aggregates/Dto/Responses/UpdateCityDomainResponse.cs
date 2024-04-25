namespace Profiles.Domain.Aggregates.Dto.Responses;

public class UpdateCityDomainResponse
{
    public string CityId { get; init; }
    public string? ProvinceId { get; set; }
    public string? Name { get; set; }
    public bool? Disabled { get; set; }
}
