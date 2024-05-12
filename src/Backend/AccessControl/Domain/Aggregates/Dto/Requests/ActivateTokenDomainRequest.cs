namespace AccessControl.Domain.Aggregates.Dto.Requests
{
  public class ActivateTokenDomainRequest
  {
    public required string ActivationToken { get; init; }
  }
}
