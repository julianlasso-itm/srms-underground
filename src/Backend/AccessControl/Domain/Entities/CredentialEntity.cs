using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities;

internal sealed class CredentialEntity
{
    public CredentialIdValueObject CredentialId { get; private set; }
    public EmailValueObject Email { get; private set; }
    public PasswordValueObject Password { get; private set; }
    public DisabledValueObject Disabled { get; private set; }
    public List<RoleEntity> Roles { get; private set; }

    public CredentialEntity() { }

    public CredentialEntity(CredentialStruct data)
    {
        if (data.CredentialId != null)
        {
            CredentialId = data.CredentialId;
        }
        if (data.Email != null)
        {
            Email = data.Email;
        }
        if (data.Password != null)
        {
            Password = data.Password;
        }
        if (data.Disabled != null)
        {
            Disabled = data.Disabled;
        }
        Roles = data.Roles ?? new List<RoleEntity>();
    }

    public void Register(
        EmailValueObject email,
        PasswordValueObject password,
        List<RoleEntity>? roles = null
    )
    {
        CredentialId = new CredentialIdValueObject(Guid.NewGuid().ToString());
        Email = email;
        Password = password;
        Disabled = new DisabledValueObject(false);
        Roles = roles ?? new List<RoleEntity>();
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

    public void AddRoles(IEnumerable<RoleEntity> roles)
    {
        Roles.AddRange(roles);
    }

    public void RemoveRoles(IEnumerable<RoleEntity> roles)
    {
        foreach (var role in roles)
        {
            Roles.Remove(role);
        }
    }
}
