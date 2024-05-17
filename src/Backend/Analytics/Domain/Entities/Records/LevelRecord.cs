using Analytics.Domain.ValueObjects;

namespace Analytics.Domain.Entities.Records
{
  internal struct LevelRecords
  {
    public LevelIdValueObject LevelId { get; set; }
    public NameValueObject Name { get; set; }
    public DescriptionValueObject? Description { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
