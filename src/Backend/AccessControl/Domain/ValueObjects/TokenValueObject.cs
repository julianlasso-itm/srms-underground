using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class TokenValueObject : BaseStringValueObject
  {
    public TokenValueObject(string value)
      : base(value)
    {
      Name = "Token";
      Validate();
    }
  }
}
