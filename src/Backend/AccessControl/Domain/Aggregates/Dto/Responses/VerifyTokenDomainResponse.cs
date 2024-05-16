namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class VerifyTokenDomainResponse
  {
    public required string Email { get; init; }
    public required List<string> Roles { get; init; }
  }
}
