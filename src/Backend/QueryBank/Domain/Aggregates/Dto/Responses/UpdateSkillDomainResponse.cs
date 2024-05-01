namespace QueryBank.Domain.Aggregates.Dto.Responses
{
  public class UpdateSkillDomainResponse
  {
    public required string SkillId { get; init; }
    public string? SubSkillId { get; set; }
    public string? Name { get; set; }
    public bool? Disabled { get; set; }
  }
}
