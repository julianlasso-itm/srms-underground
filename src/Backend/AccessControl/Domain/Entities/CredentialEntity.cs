using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities;

internal sealed class CredentialEntity
{
  public CredentialIdValueObject CredentialId { get; private set; }
  public EmailValueObject Email { get; private set; }
  public PasswordValueObject Password { get; private set; }
  public DisabledValueObject Disabled { get; private set; }

  public CredentialEntity() { }

  public CredentialEntity(CredentialStruct data)
  {
    CredentialId = data.CredentialId;
    Email = data.Email;
    Password = data.Password;
    Disabled = data.Disabled;
  }

  public void Register(EmailValueObject email, PasswordValueObject password)
  {
    CredentialId = new CredentialIdValueObject(Guid.NewGuid().ToString());
    Email = email;
    Password = password;
    Disabled = new DisabledValueObject(false);
  }

  public void UpdatePassword(PasswordValueObject password)
  {
    Password = password;
  }

  public void Enable()
  {
    Disabled = new DisabledValueObject(false);
  }

  public void Disable()
  {
    Disabled = new DisabledValueObject(true);
  }
}
