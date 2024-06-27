using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateSkillProfilesResponse
  {
    [ProtoMember(1)]
    public required string SkillId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public bool? Disabled { get; set; }
  }
}
