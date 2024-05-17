using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities
{
  internal sealed class SkillEntity
  {
    public SkillIdValueObject SkillId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }

    public SkillEntity() { }

    public SkillEntity(SkillRecord data)
    {
      SkillId = data.SkillId;
      Name = data.Name;
      Disabled = data.Disabled;
    }

    public void Register(NameValueObject name)
    {
      SkillId = new SkillIdValueObject(Guid.NewGuid().ToString());
      Name = name;
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
  }
}
