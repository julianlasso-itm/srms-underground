using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class ActivationTokenValueObject : BaseStringValueObject
  {
    public ActivationTokenValueObject(string value)
      : base(value)
    {
      Name = "ActivationToken";
      Validate();
    }
  }
}
