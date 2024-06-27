using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteSubSkillProfilesResponse
  {
    [ProtoMember(1)]
    public required string SubSkillId { get; set; }
  }
}
