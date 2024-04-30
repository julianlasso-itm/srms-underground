using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
  public sealed class ProvinceIdValueObject : BaseIdValueObject
  {
    public ProvinceIdValueObject(string value)
      : base(value)
    {
      Name = "ProvinceId";
      Validate();
    }
  }
}
