using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities
{
  internal sealed class LevelEntity
  {
    public LevelIdValueObject LevelId { get; private set; }
    public NameValueObject Name { get; private set; }
    public DescriptionValueObject? Description { get; private set; }
    public DisabledValueObject Disabled { get; private set; }

    public LevelEntity() { }

    public LevelEntity(LevelStruct data)
    {
      LevelId = data.LevelId;
      Name = data.Name;
      Description = data.Description;
      Disabled = data.Disabled;
    }

    public void Register(
      NameValueObject name,
      DescriptionValueObject? description,
      LevelIdValueObject? id,
      DisabledValueObject? disabled
    )
    {
      LevelId = id ?? new LevelIdValueObject(Guid.NewGuid().ToString());
      Name = name;
      Description = description;
      Disabled = disabled ?? new DisabledValueObject(false);
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
