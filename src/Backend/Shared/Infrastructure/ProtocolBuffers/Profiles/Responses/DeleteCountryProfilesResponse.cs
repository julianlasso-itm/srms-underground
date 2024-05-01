using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class DeleteCountryProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string CountryId { get; set; }
  }
}
