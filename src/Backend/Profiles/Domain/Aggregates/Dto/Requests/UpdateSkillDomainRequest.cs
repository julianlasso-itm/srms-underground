namespace Profiles.Domain.Aggregates.Dto.Requests
{
  public class UpdateSkillDomainRequest
  {
    public required string SkillId { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
  }
}
