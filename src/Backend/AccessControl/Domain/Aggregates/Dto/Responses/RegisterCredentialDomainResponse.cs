namespace AccessControl.Domain.Aggregates.Dto.Responses;

public class RegisterCredentialDomainResponse
{
  public required string CredentialId { get; init; }
  public required string Email { get; init; }
  public required string Password { get; init; }
  public required bool Disabled { get; init; }
}
