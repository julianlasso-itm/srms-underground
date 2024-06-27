using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class GetRolesAccessControlResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<RoleSecurity> Roles { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class RoleSecurity
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Description { get; set; }

    [ProtoMember(4)]
    public required bool Disabled { get; set; }
  }
}
