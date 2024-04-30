using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
  public sealed class DisabledValueObject : BaseBooleanValueObject
  {
    public DisabledValueObject(bool value)
      : base(value)
    {
      Name = "Disabled";
      Validate();
    }
  }
}
