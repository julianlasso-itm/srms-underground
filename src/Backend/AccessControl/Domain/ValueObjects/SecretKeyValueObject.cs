using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class SecretKeyValueObject : BaseStringValueObject
  {
    public SecretKeyValueObject(string value)
      : base(value)
    {
      Name = "SecretKey";
      Validate();
    }
  }
}
