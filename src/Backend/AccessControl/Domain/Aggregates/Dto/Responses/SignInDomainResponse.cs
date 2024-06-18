namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public sealed class SignInDomainResponse
  {
    public required string Token { get; init; }
  }
}
