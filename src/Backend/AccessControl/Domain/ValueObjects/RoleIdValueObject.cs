using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public sealed class RoleIdValueObject : BaseIdValueObject
  {
    public RoleIdValueObject(string value)
      : base(value)
    {
      Name = "RoleId";
      Validate();
    }
  }
}
