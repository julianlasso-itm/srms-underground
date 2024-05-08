using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities;

internal sealed class CredentialEntity
{
  public CredentialIdValueObject CredentialId { get; private set; }
  public FullNameValueObject Name { get; private set; }
  public EmailValueObject Email { get; private set; }
  public PasswordValueObject Password { get; private set; }
  public PhotoValueObject Photo { get; private set; }
  public DisabledValueObject Disabled { get; private set; }

  public CredentialEntity() { }

  public CredentialEntity(CredentialStruct data)
  {
    CredentialId = data.CredentialId;
    Name = data.Name;
    Email = data.Email;
    Password = data.Password;
    Photo = data.Photo;
    Disabled = data.Disabled;
  }

  public void Register(
    FullNameValueObject name,
    EmailValueObject email,
    PasswordValueObject password,
    PhotoValueObject photo
  )
  {
    CredentialId = new CredentialIdValueObject(Guid.NewGuid().ToString());
    Name = name;
    Email = email;
    Password = password;
    Photo = photo;
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

  public void UpdatePhoto(PhotoValueObject photo)
  {
    Photo = photo;
  }

  public void UpdateName(FullNameValueObject name)
  {
    Name = name;
  }
}
