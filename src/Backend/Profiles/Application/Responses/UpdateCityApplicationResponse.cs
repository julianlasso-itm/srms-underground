namespace Profiles.Application.Responses;

public sealed class UpdateCityApplicationResponse
{
    public required string CityId { get; init; }
    public string? ProvinceId { get; init; }
    public string? Name { get; init; }
    public bool? Disabled { get; init; }
}
