namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class VerifyTokenDomainResponse
  {
    public required List<string> Roles { get; init; }
  }
}
