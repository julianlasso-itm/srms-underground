using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteSkillProfilesResponse
  {
    [ProtoMember(1)]
    public required string SkillId { get; set; }
  }
}
