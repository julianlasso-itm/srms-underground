using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class PhotoValueObject : BaseStringValueObject
  {
    public PhotoValueObject(string value)
      : base(value)
    {
      Name = "Photo";
      Validate();
    }

    public sealed override void Validate()
    {
      base.Validate();
      if (ValidateUrl(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} must be a valid URL"));
      }
    }

    private static bool ValidateUrl(string value)
    {
      return !Uri.IsWellFormedUriString(value, UriKind.Absolute);
    }
  }
}
