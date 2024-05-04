using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class ExpirationValueObject : BaseStringValueObject
  {
    private const int MaxLength = 33;

    public ExpirationValueObject(string value)
      : base(value)
    {
      Name = "Expiration";
      Validate();
    }

    public sealed override void Validate()
    {
      base.Validate();
      if (!IsLengthValid(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} must be less than {MaxLength} characters"));
      }
    }

    private static bool IsLengthValid(string value)
    {
      return value.Length <= MaxLength;
    }
  }
}
