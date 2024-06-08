namespace Profiles.Application.Responses
{
  public class RegisterSquadApplicationResponse
  {
    public required string SquadId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
  }
}
