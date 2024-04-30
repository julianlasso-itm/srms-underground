using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
  public sealed class NameValueObject : BaseStringValueObject
  {
    private const int MaxLength = 100;

    public NameValueObject(string value)
      : base(value)
    {
      Name = "Name";
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
