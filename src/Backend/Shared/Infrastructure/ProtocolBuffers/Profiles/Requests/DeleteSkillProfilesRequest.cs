using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteSkillProfilesRequest
  {
    [ProtoMember(1)]
    public required string SkillId { get; set; }
  }
}
