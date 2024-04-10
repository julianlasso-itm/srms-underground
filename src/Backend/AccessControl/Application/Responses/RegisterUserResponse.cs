namespace AccessControl.Application.Responses;

public sealed class RegisterUserResponse
{
    public required string UserId { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required bool Disabled { get; init; }
}
