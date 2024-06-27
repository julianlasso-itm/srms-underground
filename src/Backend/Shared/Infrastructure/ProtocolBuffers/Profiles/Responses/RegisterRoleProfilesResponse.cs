using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class RegisterRoleProfilesResponse
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Description { get; set; }

    [ProtoMember(4)]
    public required bool Disabled { get; set; }

    [ProtoMember(5)]
    public required IEnumerable<string>? Skills { get; set; }
  }
}
