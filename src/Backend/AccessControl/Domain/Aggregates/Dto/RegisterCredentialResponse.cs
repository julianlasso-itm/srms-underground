namespace AccessControl.Domain.Aggregates.Dto;

public class RegisterCredentialResponse
{
    public required string CredentialId { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required bool Disabled { get; init; }
}
