using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs;

internal struct ProvinceStruct
{
    public ProvinceIdValueObject ProvinceId { get; set; }
    public CountryIdValueObject CountryId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
    public CountryStruct Country { get; set; }
    public List<CityStruct> Cities { get; set; }
}
