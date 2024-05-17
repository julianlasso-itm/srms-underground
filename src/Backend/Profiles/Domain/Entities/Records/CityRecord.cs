using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Records
{
  internal struct CityRecord
  {
    public CityIdValueObject CityId { get; set; }
    public ProvinceIdValueObject ProvinceId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
