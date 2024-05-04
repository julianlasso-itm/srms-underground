using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class JwtValueObject : BaseStringValueObject
  {
    public JwtValueObject(string value)
      : base(value)
    {
      Name = "Jwt";
      Validate();
    }
  }
}
