using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteProvinceProfilesRequest
  {
    [ProtoMember(1)]
    public required string ProvinceId { get; set; }
  }
}
