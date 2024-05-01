namespace QueryBank.Application.Commands
{
  public class UpdateSkillCommand
  {
    public required string SkillId { get; init; }
    public string? SubSkillId { get; init; }
    public string? Name { get; init; }
    public bool? Disabled { get; init; }
  }
}
