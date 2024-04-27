using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs;

internal struct RoleStruct
{
    public RoleIdValueObject RoleId { get; set; }
    public NameValueObject Name { get; set; }
    public DescriptionValueObject? Description { get; set; }
    public DisabledValueObject Disabled { get; set; }
}
