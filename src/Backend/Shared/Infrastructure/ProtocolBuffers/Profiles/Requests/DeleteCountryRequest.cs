using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class DeleteCountryRequest
  {
    [DataMember(Order = 1)]
    public required string CountryId { get; set; }
  }
}
