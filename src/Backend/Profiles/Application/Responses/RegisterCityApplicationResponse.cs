namespace Profiles.Application.Responses
{
  public sealed class RegisterCityApplicationResponse
  {
    public required string CityId { get; init; }
    public required string ProvinceId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
  }
}
