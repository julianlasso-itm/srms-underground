namespace Profiles.Domain.Aggregates.Dto.Responses
{
  public class RegisterCountryDomainResponse
  {
    public required string CountryId { get; init; }
    public string Name { get; init; }
    public bool Disabled { get; init; }
  }
}
