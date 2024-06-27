using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetRolesProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<RoleProfiles> Roles { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class RoleProfiles
  {
    [ProtoMember(1)]
    public string RoleId { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Description { get; set; }

    [ProtoMember(4)]
    public bool Disabled { get; set; }

    [ProtoMember(5)]
    public IEnumerable<SkillProfiles> Skills { get; set; }
  }
}
