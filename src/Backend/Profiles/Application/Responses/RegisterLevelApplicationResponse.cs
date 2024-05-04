namespace Profiles.Application.Responses
{
  public sealed class RegisterLevelApplicationResponse
  {
    public required string LevelId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required bool Disabled { get; init; }
  }
}
