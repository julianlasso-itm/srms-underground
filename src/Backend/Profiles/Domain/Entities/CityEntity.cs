using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities;

internal sealed class CityEntity
{
    public CityIdValueObject CityId { get; private set; }
    public ProvinceIdValueObject ProvinceId { get; private set; }
    public NameValueObject Name { get; private set; }
    public DisabledValueObject Disabled { get; private set; }

    public CityEntity() { }

    public CityEntity(CityStruct data)
    {
        CityId = data.CityId;
        ProvinceId = data.ProvinceId;
        Name = data.Name;
        Disabled = data.Disabled;
    }

    public void Register(ProvinceIdValueObject provinceId, NameValueObject name)
    {
        CityId = new CityIdValueObject(Guid.NewGuid().ToString());
        ProvinceId = provinceId;
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

    public void UpdateProvince(ProvinceIdValueObject provinceId)
    {
        ProvinceId = provinceId;
    }
}
