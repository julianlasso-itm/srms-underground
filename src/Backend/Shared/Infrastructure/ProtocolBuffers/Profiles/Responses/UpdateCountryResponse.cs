using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class UpdateCountryResponse
  {
    [DataMember(Order = 1)]
    public required string CountryId { get; set; }

    [DataMember(Order = 2)]
    public string? Name { get; set; }

    [DataMember(Order = 3)]
    public bool? Disabled { get; set; }
  }
}
