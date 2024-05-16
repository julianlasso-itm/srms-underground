namespace AccessControl.Domain.Aggregates.Dto.Requests
{
  public sealed class SignInDataInitialsDomainRequest
  {
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string PrivateKeyPath { get; init; }
    public required string PublicKeyPath { get; init; }
  }
}
