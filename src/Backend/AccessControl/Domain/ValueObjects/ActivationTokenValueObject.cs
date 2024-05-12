using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class ActivationTokenValueObject : BaseStringValueObject
  {
    private const int MaxLength = 32;

    public ActivationTokenValueObject(string value)
      : base(value)
    {
      Name = "ActivationToken";
      Validate();
    }

    public override void Validate()
    {
      base.Validate();
      if (!IsLengthValid(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} must be less than {MaxLength} characters"));
        return;
      }

      if (!IsUUIDValid(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} must be a valid token"));
        return;
      }
    }

    private static bool IsLengthValid(string value)
    {
      return value.Length <= MaxLength;
    }

    private static bool IsUUIDValid(string value)
    {
      return Guid.TryParseExact(value, "N", out _);
    }
  }
}
