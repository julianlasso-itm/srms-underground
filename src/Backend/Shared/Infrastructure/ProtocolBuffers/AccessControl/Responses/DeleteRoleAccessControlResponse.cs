using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class DeleteRoleAccessControlResponse
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }
  }
}
