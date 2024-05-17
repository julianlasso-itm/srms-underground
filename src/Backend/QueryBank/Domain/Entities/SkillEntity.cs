using QueryBank.Domain.Entities.Records;
using QueryBank.Domain.ValueObjects;

namespace QueryBank.Domain.Entities
{
  internal sealed class SkillEntity
  {
    public SkillIdValueObject SkillId { get; set; }
    public SkillIdValueObject? SubSkillId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }

    public SkillEntity() { }

    public SkillEntity(SkillRecord data)
    {
      SkillId = data.SkillId;
      SubSkillId = data.SubSkillId;
      Name = data.Name;
      Disabled = data.Disabled;
    }

    public void Register(
      NameValueObject name,
      SkillIdValueObject? skillId,
      SkillIdValueObject? subSkillId,
      DisabledValueObject? disabled
    )
    {
      SkillId = skillId ?? new SkillIdValueObject(Guid.NewGuid().ToString());
      SubSkillId = subSkillId;
      Name = name;
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

    public void UpdateSubSkillId(SkillIdValueObject subSkillId)
    {
      SubSkillId = subSkillId;
    }
  }
}
