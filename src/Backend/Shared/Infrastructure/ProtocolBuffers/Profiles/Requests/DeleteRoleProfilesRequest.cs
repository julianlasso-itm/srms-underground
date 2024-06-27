using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteRoleProfilesRequest
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }
  }
}
