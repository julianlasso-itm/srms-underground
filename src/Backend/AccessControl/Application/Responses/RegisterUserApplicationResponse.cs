namespace AccessControl.Application.Responses
{
  public sealed class RegisterUserApplicationResponse
  {
    public required string UserId { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string Photo { get; init; }
    public required bool Disabled { get; init; }
  }
}
