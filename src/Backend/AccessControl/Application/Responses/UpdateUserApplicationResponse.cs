namespace AccessControl.Application.Responses
{
  public sealed class UpdateUserApplicationResponse
  {
    public required string UserId { get; init; }
    public string? Name { get; init; }
    public string? Photo { get; init; }
    public bool? Disabled { get; init; }
    public string? CityId { get; init; }
  }
}
