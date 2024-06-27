using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class RegisterRoleAccessControlRequest
  {
    [ProtoMember(1)]
    public required string Name { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Description { get; set; }
  }
}
