namespace Profiles.Application.Responses
{
  public class UpdateSubSkillApplicationResponse
  {
    public required string SubSkillId { get; init; }
    public required string? SkillId { get; init; }
    public string? Name { get; init; }
    public bool? Disabled { get; init; }
  }
}
