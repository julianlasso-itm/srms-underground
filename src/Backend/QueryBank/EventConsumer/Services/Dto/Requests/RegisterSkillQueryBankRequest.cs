namespace QueryBank.EventConsumer.Services.Dto.Requests
{
  public class RegisterSkillQueryBankRequest
  {
    public required string SkillId { get; init; }
    public string? SubSkillId { get; init; }
    public required string Name { get; init; }
    public bool Disabled { get; init; }
  }
}
