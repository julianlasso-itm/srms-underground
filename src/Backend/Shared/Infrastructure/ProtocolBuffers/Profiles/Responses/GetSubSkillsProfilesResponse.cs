using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetSubSkillsProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<SubSkillProfiles> SubSkills { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class SubSkillProfiles
  {
    [ProtoMember(1)]
    public required string SubSkillId { get; set; }

    [ProtoMember(2)]
    public required string SkillId { get; set; }

    [ProtoMember(3)]
    public required string Name { get; set; }

    [ProtoMember(4)]
    public required bool Disabled { get; set; }
  }
}
