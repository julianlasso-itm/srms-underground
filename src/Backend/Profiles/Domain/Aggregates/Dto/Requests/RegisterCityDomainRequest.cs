namespace Profiles.Domain.Aggregates.Dto.Requests;

public class RegisterCityDomainRequest
{
    public required string ProvinceId { get; init; }
    public required string Name { get; init; }
}
