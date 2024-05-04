namespace AccessControl.Application.Responses
{
  public sealed class UpdateUserApplicationResponse
  {
    public required string UserId { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public bool? Disabled { get; init; }
  }
}
