using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterSquadProfilesRequest
  {
    [ProtoMember(1)]
    public string Name { get; set; }
  }
}
