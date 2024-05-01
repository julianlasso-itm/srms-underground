using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetCountriesProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<CountryProfiles> Countries { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class CountryProfiles
  {
    [DataMember(Order = 1)]
    public required string CountryId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; set; }
  }
}
