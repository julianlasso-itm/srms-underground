namespace AccessControl.Domain.Aggregates.Dto.Requests
{
  public sealed class SignInDomainRequest
  {
    public required string CredentialId { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Photo { get; init; }
    public required string PrivateKeyPath { get; init; }
    public required string PublicKeyPath { get; init; }
  }
}
