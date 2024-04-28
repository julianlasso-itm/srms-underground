using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs;

internal struct CityStruct
{
    public CityIdValueObject CityId { get; set; }
    public ProvinceIdValueObject ProvinceId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
}
