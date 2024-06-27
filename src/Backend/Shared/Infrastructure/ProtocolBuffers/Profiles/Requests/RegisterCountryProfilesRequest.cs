using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterCountryProfilesRequest
  {
    [ProtoMember(1)]
    public required string Name { get; set; }
  }
}
