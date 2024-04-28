namespace Profiles.Application.Responses;

public sealed class RegisterProvinceApplicationResponse
{
    public required string ProvinceId { get; init; }
    public required string CountryId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
}
