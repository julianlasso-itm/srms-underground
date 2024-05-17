using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Records
{
  internal struct ProvinceRecord
  {
    public ProvinceIdValueObject ProvinceId { get; set; }
    public CountryIdValueObject CountryId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
