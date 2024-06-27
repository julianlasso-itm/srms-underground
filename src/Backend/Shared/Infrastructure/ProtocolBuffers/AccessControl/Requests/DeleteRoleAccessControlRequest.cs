using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class DeleteRoleAccessControlRequest
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }
  }
}
