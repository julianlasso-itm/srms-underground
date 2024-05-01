namespace QueryBank.Domain.Aggregates.Dto.Requests
{
  public class RegisterSkillDomainRequest
  {
    public string SkillId { get; init; }
    public string Name { get; init; }
    public string? SubSkillId { get; init; }
    public bool Disable { get; init; }
  }
}
