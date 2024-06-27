using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class UpdateRoleAccessControlResponse
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public string? Description { get; set; }

    [ProtoMember(4)]
    public bool? Disabled { get; set; }
  }
}
