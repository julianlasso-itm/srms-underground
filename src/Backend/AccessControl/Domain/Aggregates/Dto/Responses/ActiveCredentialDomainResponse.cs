namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class ActiveCredentialDomainResponse
  {
    public required string CredentialId { get; init; }
    public required bool Disabled { get; init; }
  }
}
