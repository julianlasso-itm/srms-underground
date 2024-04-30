namespace Profiles.Application.Responses
{
  public sealed class RegisterCountryApplicationResponse
  {
    public required string CountryId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
  }
}
