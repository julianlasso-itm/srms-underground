using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class UpdateProvinceProfilesRequest
  {
    [DataMember(Order = 1, IsRequired = false)]
    public string? ProvinceId { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? CountryId { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? Name { get; set; }

    [DataMember(Order = 4, IsRequired = false)]
    public bool? Disable { get; set; }
  }
}
