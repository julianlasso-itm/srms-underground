using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
  public sealed class CountryIdValueObject : BaseIdValueObject
  {
    public CountryIdValueObject(string value)
      : base(value)
    {
      Name = "CountryId";
      Validate();
    }
  }
}
