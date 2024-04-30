namespace Profiles.Domain.Aggregates.Dto.Responses
{
  public class UpdateProvinceDomainResponse
  {
    public required string ProvinceId { get; init; }
    public string? CountryId { get; set; }
    public string? Name { get; set; }
    public bool? Disabled { get; set; }
  }
}
