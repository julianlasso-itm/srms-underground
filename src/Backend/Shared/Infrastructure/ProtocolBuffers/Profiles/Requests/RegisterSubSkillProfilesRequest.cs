using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterSubSkillProfilesRequest
  {
    [ProtoMember(1)]
    public string SkillId { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }
  }
}
