using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
  public sealed class CityIdValueObject : BaseIdValueObject
  {
    public CityIdValueObject(string value)
      : base(value)
    {
      Name = "CityId";
      Validate();
    }
  }
}
