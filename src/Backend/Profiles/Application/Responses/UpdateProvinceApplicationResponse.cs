namespace Profiles.Application.Responses;

public sealed class UpdateProvinceApplicationResponse
{
    public required string ProvinceId { get; init; }
    public string? CountryId { get; init; }
    public string? Name { get; init; }
    public bool? Disabled { get; init; }
}
