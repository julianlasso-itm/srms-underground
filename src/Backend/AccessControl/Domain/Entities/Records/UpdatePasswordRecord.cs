using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Records
{
  public record UpdatePasswordRecord
  {
    public CredentialIdValueObject CredentialId { get; set; }
    public PasswordValueObject OldPassword { get; set; }
    public PasswordValueObject NewPassword { get; set; }
  }
}
