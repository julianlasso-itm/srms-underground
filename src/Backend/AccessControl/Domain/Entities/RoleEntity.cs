using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities;

internal sealed class RoleEntity
{
    public RoleIdValueObject RoleId { get; private set; }
    public NameValueObject Name { get; private set; }
    public DescriptionValueObject? Description { get; private set; }
    public DisabledValueObject Disabled { get; private set; }
    public List<CredentialEntity> Credentials { get; private set; }

    public RoleEntity() { }

    public RoleEntity(RoleStruct data)
    {
        RoleId = data.RoleId;
        Name = data.Name;
        Description = data.Description;
        Disabled = data.Disabled;
        Credentials = data.Credentials ?? new List<CredentialEntity>();
    }

    public void Register(
        NameValueObject name,
        DescriptionValueObject? description,
        List<CredentialEntity>? credentials = null
    )
    {
        RoleId = new RoleIdValueObject(Guid.NewGuid().ToString());
        Name = name;
        if (description != null)
        {
            Description = description;
        }
        Disabled = new DisabledValueObject(false);
        Credentials = credentials ?? new List<CredentialEntity>();
    }

    public void Enable()
    {
        Disabled = new DisabledValueObject(false);
    }

    public void Disable()
    {
        Disabled = new DisabledValueObject(true);
    }

    public void UpdateName(NameValueObject name)
    {
        Name = name;
    }

    public void UpdateDescription(DescriptionValueObject description)
    {
        Description = description;
    }

    public void AddCredentials(IEnumerable<CredentialEntity> credentials)
    {
        Credentials ??= new List<CredentialEntity>();
        Credentials.AddRange(credentials);
    }

    public void RemoveCredentials(IEnumerable<CredentialEntity> credentials)
    {
        if (Credentials != null)
        {
            foreach (var credential in credentials)
            {
                Credentials.Remove(credential);
            }
        }
    }

    public void RemoveAllCredentials()
    {
        if (Credentials != null)
        {
            Credentials.Clear();
        }
    }
}
