using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public class CityIdValueObject : BaseIdValueObject
  {
    public CityIdValueObject(string value)
      : base(value)
    {
      Name = "CityId";
      Validate();
    }
  }
}
