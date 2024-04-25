namespace Profiles.Domain.Aggregates.Dto.Responses;

public class RegisterCityDomainResponse
{
    public required string CityId { get; init; }
    public required string ProvinceId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
}
