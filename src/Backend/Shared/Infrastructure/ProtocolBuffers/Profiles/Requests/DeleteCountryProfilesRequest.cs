using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class DeleteCountryProfilesRequest
  {
    [DataMember(Order = 1)]
    public required string CountryId { get; set; }
  }
}
