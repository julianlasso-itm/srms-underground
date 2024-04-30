using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities
{
  internal sealed class ProvinceEntity
  {
    public ProvinceIdValueObject ProvinceId { get; private set; }
    public CountryIdValueObject CountryId { get; private set; }
    public NameValueObject Name { get; private set; }
    public DisabledValueObject Disabled { get; private set; }

    public ProvinceEntity() { }

    public ProvinceEntity(ProvinceStruct data)
    {
      ProvinceId = data.ProvinceId;
      CountryId = data.CountryId;
      Name = data.Name;
      Disabled = data.Disabled;
    }

    public void Register(CountryIdValueObject countryId, NameValueObject name)
    {
      ProvinceId = new ProvinceIdValueObject(Guid.NewGuid().ToString());
      CountryId = countryId;
      Name = name;
      Disabled = new DisabledValueObject(false);
    }

    public void Enable()
    {
      Disabled = new DisabledValueObject(false);
    }

    public void Disable()
    {
      Disabled = new DisabledValueObject(true);
    }

    public void UpdateName(NameValueObject name)
    {
      Name = name;
    }

    public void UpdateCountry(CountryIdValueObject countryId)
    {
      CountryId = countryId;
    }
  }
}
