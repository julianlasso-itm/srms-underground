using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Records
{
  internal struct CountryRecord
  {
    public CountryIdValueObject CountryId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
  }
}
