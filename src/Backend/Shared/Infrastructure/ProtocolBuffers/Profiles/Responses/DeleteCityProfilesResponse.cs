using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteCityProfilesResponse
  {
    [ProtoMember(1)]
    public required string CityId { get; set; }
  }
}
