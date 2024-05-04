namespace Profiles.Domain.Aggregates.Dto.Requests
{
  public class RegisterLevelDomainRequest
  {
    public string? LevelId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public bool? Disabled { get; init; }
  }
}
