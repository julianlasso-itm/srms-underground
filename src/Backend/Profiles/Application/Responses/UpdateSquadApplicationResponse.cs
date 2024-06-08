namespace Profiles.Application.Responses
{
  public class UpdateSquadApplicationResponse
  {
    public required string SquadId { get; init; }
    public string? Name { get; init; }
    public bool? Disabled { get; init; }
  }
}
