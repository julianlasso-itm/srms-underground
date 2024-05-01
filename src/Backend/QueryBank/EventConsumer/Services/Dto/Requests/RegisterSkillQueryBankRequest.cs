using System.Text.Json.Serialization;

namespace QueryBank.EventConsumer.Services.Dto.Requests
{
  public class RegisterSkillQueryBankRequest
  {
    public required string SkillId { get; init; }

    public string? SubSkillId { get; init; }

    public required string Name { get; init; }

    [JsonPropertyName("Disabled")]
    public bool Disable { get; init; }
  }
}
