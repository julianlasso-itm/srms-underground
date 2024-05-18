namespace AccessControl.Application.Responses
{
  public class VerifyTokenApplicationResponse
  {
    public required string UserId { get; init; }
    public required string Email { get; init; }
    public required string Photo { get; init; }
    public required List<string> Roles { get; init; }
  }
}
