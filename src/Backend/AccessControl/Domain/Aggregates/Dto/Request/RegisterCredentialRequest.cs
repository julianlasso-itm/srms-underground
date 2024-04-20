namespace AccessControl.Domain.Aggregates.Dto;

public class RegisterCredentialRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}
