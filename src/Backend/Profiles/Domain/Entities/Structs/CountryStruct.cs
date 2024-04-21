using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs;

internal struct CountryStruct
{
    public CountryIdValueObject CountryId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
}
