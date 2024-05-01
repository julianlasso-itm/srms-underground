namespace QueryBank.Domain.Aggregates.Dto.Requests
{
  public class RegisterSkillDomainRequest
  {
    public string Name { get; init; }
    public string? SubSkillId { get; init; }
  }
}
