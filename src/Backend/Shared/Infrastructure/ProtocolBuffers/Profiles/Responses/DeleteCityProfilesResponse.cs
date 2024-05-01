using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class DeleteCityProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string CityId { get; set; }
  }
}
