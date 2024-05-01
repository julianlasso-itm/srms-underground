namespace QueryBank.Application.Responses
{
  public class RegisterSkillApplicationResponse
  {
    public required string SkillId { get; init; }
    public string? SubSkillId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
  }
}
