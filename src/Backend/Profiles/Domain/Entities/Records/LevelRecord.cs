using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Records
{
  internal struct LevelRecord
  {
    public LevelIdValueObject LevelId { get; set; }
    public NameValueObject Name { get; set; }
    public DescriptionValueObject? Description { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
