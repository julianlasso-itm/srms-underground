using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class TokenIdValueObject : BaseIdValueObject
  {
    public TokenIdValueObject(string value)
      : base(value)
    {
      Name = "TokenId";
      Validate();
    }
  }
}
