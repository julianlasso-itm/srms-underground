using Analytics.Domain.Entities.Records;
using Analytics.Domain.ValueObjects;

namespace Analytics.Domain.Entities
{
  internal sealed class LevelEntity
  {
    public LevelIdValueObject LevelId { get; private set; }
    public NameValueObject Name { get; private set; }
    public DescriptionValueObject? Description { get; private set; }
    public DisabledValueObject Disabled { get; private set; }

    public LevelEntity() { }

    public LevelEntity(LevelRecords data)
    {
      LevelId = data.LevelId;
      Name = data.Name;
      Description = data.Description;
      Disabled = data.Disabled;
    }

    public void Register(NameValueObject name, DescriptionValueObject? description)
    {
      LevelId = new LevelIdValueObject(Guid.NewGuid().ToString());
      Name = name;
      Description = description;
      Disabled = new DisabledValueObject(false);
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
  }
}
