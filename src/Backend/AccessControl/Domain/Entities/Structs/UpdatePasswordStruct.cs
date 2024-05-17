using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Structs
{
  public struct UpdatePasswordStruct
  {
    public CredentialIdValueObject CredentialId { get; set; }
    public PasswordValueObject OldPassword { get; set; }
    public PasswordValueObject NewPassword { get; set; }
  }
}
