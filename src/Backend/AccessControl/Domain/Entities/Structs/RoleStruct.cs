using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Structs;

internal struct RoleStruct
{
    public RoleIdValueObject RoleId { get; set; }
    public NameValueObject Name { get; set; }
    public DescriptionValueObject? Description { get; set; }
    public DisabledValueObject Disabled { get; set; }
    public List<CredentialEntity> Credentials { get; set; }
}
