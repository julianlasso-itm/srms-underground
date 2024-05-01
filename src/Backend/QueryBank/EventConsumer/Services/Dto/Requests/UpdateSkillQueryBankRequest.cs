namespace QueryBank.EventConsumer.Services.Dto.Requests
{
  public class UpdateSkillQueryBankRequest
  {
    public required string SkillId { get; init; }
    public string? SubSkillId { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
  }
}
