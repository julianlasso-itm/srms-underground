namespace Profiles.Domain.Aggregates.Dto.Responses
{
  public class RegisterProvinceDomainResponse
  {
    public required string ProvinceId { get; init; }
    public required string CountryId { get; init; }
    public string Name { get; init; }
    public bool Disabled { get; init; }
  }
}
