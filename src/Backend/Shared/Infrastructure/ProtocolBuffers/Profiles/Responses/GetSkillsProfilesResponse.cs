using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetSkillsProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<SkillProfiles> Skills { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class SkillProfiles
  {
    [ProtoMember(1)]
    public required string SkillId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3)]
    public required bool Disabled { get; set; }
  }
}
