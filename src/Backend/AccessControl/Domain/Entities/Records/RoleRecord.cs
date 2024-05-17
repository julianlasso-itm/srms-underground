using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Records
{
  internal record RoleRecord
  {
    public RoleIdValueObject RoleId { get; set; }
    public NameValueObject Name { get; set; }
    public DescriptionValueObject? Description { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
