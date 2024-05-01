using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetProvincesProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<ProvinceProfiles> Provinces { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class ProvinceProfiles
  {
    [DataMember(Order = 1)]
    public required string ProvinceId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required string CountryId { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }

    [DataMember(Order = 5)]
    public required CountryProfiles Country { get; set; }
  }
}
