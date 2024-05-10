using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities;

internal sealed class CredentialEntity
{
  public CredentialIdValueObject CredentialId { get; private set; }
  public FullNameValueObject Name { get; private set; }
  public EmailValueObject Email { get; private set; }
  public PasswordValueObject Password { get; private set; }
  public AvatarValueObject Avatar { get; private set; }
  public DisabledValueObject Disabled { get; private set; }
  public ICollection<RoleEntity> Roles { get; private set; } = new List<RoleEntity>();

  public CredentialEntity() { }

  public CredentialEntity(CredentialStruct data)
  {
    CredentialId = data.CredentialId;
    Name = data.Name;
    Email = data.Email;
    Password = data.Password;
    Avatar = data.Avatar;
    Disabled = data.Disabled;
  }

  public void Register(
    FullNameValueObject name,
    EmailValueObject email,
    PasswordValueObject password,
    AvatarValueObject avatar,
    DisabledValueObject? disabled
  )
  {
    CredentialId = new CredentialIdValueObject(Guid.NewGuid().ToString());
    Name = name;
    Email = email;
    Password = password;
    Avatar = avatar;
    Disabled = disabled ?? new DisabledValueObject(false);
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

  public void UpdateAvatar(AvatarValueObject avatar)
  {
    Avatar = avatar;
  }

  public void UpdateName(FullNameValueObject name)
  {
    Name = name;
  }

  public void AddRole(RoleEntity role)
  {
    Roles.Add(role);
  }

  public void RemoveRole(RoleEntity role)
  {
    Roles.Remove(role);
  }

  public void ClearRoles()
  {
    Roles.Clear();
  }
}
