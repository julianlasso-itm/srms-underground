using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterCityProfilesRequest
  {
    [ProtoMember(1)]
    public required string Name { get; set; }

    [ProtoMember(2)]
    public required string ProvinceId { get; set; }
  }
}
