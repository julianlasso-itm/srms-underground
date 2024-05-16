namespace AccessControl.Application.Responses
{
  public class VerifyTokenApplicationResponse
  {
    public required List<string> Roles { get; init; }
  }
}
