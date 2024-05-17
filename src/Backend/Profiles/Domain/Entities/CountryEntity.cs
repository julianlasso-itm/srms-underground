using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities
{
  internal sealed class CountryEntity
  {
    public CountryIdValueObject CountryId { get; private set; }
    public NameValueObject Name { get; private set; }
    public DisabledValueObject Disabled { get; private set; }

    public CountryEntity() { }

    public CountryEntity(CountryRecord data)
    {
      CountryId = data.CountryId;
      Name = data.Name;
      Disabled = data.Disabled;
    }

    public void Register(NameValueObject name)
    {
      CountryId = new CountryIdValueObject(Guid.NewGuid().ToString());
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
  }
}
