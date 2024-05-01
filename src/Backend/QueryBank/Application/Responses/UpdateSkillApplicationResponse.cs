namespace QueryBank.Application.Responses
{
  public class UpdateSkillApplicationResponse
  {
    public required string SkillId { get; init; }
    public string? SubSkillId { get; init; }
    public string? Name { get; init; }
    public bool? Disabled { get; init; }
  }
}
