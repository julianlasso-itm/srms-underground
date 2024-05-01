using QueryBank.Domain.Entities.Structs;
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

    public SkillEntity(SkillStruct data)
    {
      SkillId = data.SkillId;
      SubSkillId = data.SubSkillId;
      Name = data.Name;
      Disabled = data.Disabled;
    }

    public void Register(NameValueObject name, SkillIdValueObject? subSkillId)
    {
      SkillId = new SkillIdValueObject(Guid.NewGuid().ToString());
      SubSkillId = subSkillId;
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

    public void UpdateSubSkillId(SkillIdValueObject subSkillId)
    {
      SubSkillId = subSkillId;
    }
  }
}
