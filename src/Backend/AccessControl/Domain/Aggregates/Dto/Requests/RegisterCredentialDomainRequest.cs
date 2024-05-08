namespace AccessControl.Domain.Aggregates.Dto.Requests;

public class RegisterCredentialDomainRequest
{
  public required string Name { get; init; }
  public required string Email { get; init; }
  public required string Password { get; init; }
  public required string Photo { get; init; }
}
