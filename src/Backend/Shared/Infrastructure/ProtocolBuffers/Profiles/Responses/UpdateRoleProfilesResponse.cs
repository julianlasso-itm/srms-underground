using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateRoleProfilesResponse
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public string? Description { get; set; }

    [ProtoMember(4)]
    public bool? Disabled { get; set; }

    [ProtoMember(5)]
    public IEnumerable<string>? Skills { get; set; }
  }
}
