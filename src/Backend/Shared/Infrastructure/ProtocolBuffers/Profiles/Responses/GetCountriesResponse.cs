using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetCountriesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<Country> Countries { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class Country
  {
    [DataMember(Order = 1)]
    public required string CountryId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; set; }
  }
}
