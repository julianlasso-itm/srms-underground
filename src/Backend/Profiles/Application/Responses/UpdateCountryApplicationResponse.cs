namespace Profiles.Application.Responses
{
  public sealed class UpdateCountryApplicationResponse
  {
    public required string CountryId { get; init; }
    public string? Name { get; init; }
    public bool? Disabled { get; init; }
  }
}
