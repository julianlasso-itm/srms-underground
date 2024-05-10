namespace AccessControl.Domain.Aggregates.Dto.Responses;

public class RegisterCredentialDomainResponse
{
  public required string CredentialId { get; init; }
  public required string Name { get; init; }
  public required string Email { get; init; }
  public required string Password { get; init; }
  public required byte[] Avatar { get; init; }
  public required string AvatarExtension { get; init; }
  public required string Photo { get; set; }
  public required bool Disabled { get; init; }
}
