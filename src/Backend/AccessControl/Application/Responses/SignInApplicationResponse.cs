namespace AccessControl.Application.Responses
{
  public sealed class SignInApplicationResponse
  {
    public string UserId { get; init; }
    public string Name { get; init; }
    public string Token { get; init; }
  }
}
