using Shared.Domain.ValueObjects.Base;

namespace Analytics.Domain.ValueObjects
{
  public class LevelIdValueObject : BaseIdValueObject
  {
    public LevelIdValueObject(string value)
      : base(value)
    {
      Name = "LevelId";
      Validate();
    }
  }
}
