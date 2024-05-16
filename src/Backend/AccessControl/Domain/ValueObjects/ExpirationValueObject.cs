using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class ExpirationValueObject : BaseValueObject<long>
  {
    public ExpirationValueObject(long value)
      : base(value)
    {
      Name = "Expiration";
      Validate();
    }

    public sealed override void Validate()
    {
      if (!IsValueValid(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} is required"));
      }
    }

    private static bool IsValueValid(long value)
    {
      return value > 0;
    }
  }
}
