using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterSkillProfilesRequest
  {
    [ProtoMember(1)]
    public string Name { get; set; }
  }
}
