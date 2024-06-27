using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateSubSkillProfilesResponse
  {
    [ProtoMember(1)]
    public required string SubSkillId { get; set; }

    [ProtoMember(2)]
    public required string SkillId { get; set; }

    [ProtoMember(3)]
    public string? Name { get; set; }

    [ProtoMember(4)]
    public bool? Disabled { get; set; }
  }
}
