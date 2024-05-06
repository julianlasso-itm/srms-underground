using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Structs;

internal struct CredentialStruct
{
  public CredentialIdValueObject CredentialId { get; set; }
  public EmailValueObject Email { get; set; }
  public PasswordValueObject Password { get; set; }
  public DisabledValueObject Disabled { get; set; }
}