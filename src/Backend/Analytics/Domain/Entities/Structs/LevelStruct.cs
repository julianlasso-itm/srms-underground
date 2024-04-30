using Analytics.Domain.ValueObjects;

namespace Analytics.Domain.Entities.Structs
{
  internal struct LevelStruct
  {
    public LevelIdValueObject LevelId { get; set; }
    public NameValueObject Name { get; set; }
    public DescriptionValueObject? Description { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
