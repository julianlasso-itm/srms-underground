using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
  public sealed class SkillIdValueObject : BaseIdValueObject
  {
    public SkillIdValueObject(string value)
      : base(value)
    {
      Name = "SkillId";
      Validate();
    }
  }
}
