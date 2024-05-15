namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public sealed class SignInDataInitialsDomainResponse
  {
    public string Email { get; init; }
    public string Password { get; init; }
  }
}
