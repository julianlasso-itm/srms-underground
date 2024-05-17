namespace AccessControl.Domain.Aggregates.Dto.Requests
{
  public class ChangePasswordDomainRequest
  {
    public required string CredentialId { get; set; }
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }
  }
}
