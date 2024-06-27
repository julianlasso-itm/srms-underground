using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteProvinceProfilesResponse
  {
    [ProtoMember(1)]
    public required string ProvinceId { get; set; }
  }
}
