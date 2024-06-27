using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteCityProfilesRequest
  {
    [ProtoMember(1)]
    public required string CityId { get; set; }
  }
}
