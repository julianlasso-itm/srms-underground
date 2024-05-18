namespace AccessControl.Domain.Aggregates.Dto.Requests
{
  public sealed class UpdateCredentialDomainRequest
  {
    public required string CredentialId { get; init; }
    public string? Name { get; init; }
    public byte[]? Avatar { get; init; }
    public string? AvatarExtension { get; init; }
    public bool? Disabled { get; init; }
  }
}
