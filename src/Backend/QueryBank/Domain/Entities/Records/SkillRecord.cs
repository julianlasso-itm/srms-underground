using QueryBank.Domain.ValueObjects;

namespace QueryBank.Domain.Entities.Records
{
  internal struct SkillRecord
  {
    public SkillIdValueObject SkillId { get; set; }
    public SkillIdValueObject? SubSkillId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
