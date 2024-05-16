namespace AccessControl.Domain.Aggregates.Dto.Requests
{
  public class VerifyTokenDomainRequest
  {
    public required string Token { get; set; }
    public required string PrivateKeyPath { get; set; }
    public required string PublicKeyPath { get; set; }
  }
}
