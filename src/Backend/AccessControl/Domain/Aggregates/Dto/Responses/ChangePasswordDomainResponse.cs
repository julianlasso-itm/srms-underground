namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class ChangePasswordDomainResponse
  {
    public required string CredentialId { get; set; }
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }
  }
}
