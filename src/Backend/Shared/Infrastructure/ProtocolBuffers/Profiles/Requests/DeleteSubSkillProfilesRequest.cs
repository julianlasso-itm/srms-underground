using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteSubSkillProfilesRequest
  {
    [ProtoMember(1)]
    public required string SubSkillId { get; set; }
  }
}
