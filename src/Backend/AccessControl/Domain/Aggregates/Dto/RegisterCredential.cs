namespace AccessControl.Domain.Aggregates.Dto;

public class RegisterCredential
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}
