namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public sealed class UpdateCredentialDomainResponse
  {
    public string CredentialId { get; set; }
    public string? Name { get; set; }
    public byte[]? Avatar { get; set; }
    public string? AvatarExtension { get; set; }
    public string? Photo { get; set; }
    public bool? Disabled { get; set; }
  }
}
