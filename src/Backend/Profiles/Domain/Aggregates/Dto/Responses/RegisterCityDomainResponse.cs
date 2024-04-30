namespace Profiles.Domain.Aggregates.Dto.Responses
{
  public class RegisterCityDomainResponse
  {
    public required string CityId { get; init; }
    public required string ProvinceId { get; init; }
    public string Name { get; init; }
    public bool Disabled { get; init; }
  }
}
