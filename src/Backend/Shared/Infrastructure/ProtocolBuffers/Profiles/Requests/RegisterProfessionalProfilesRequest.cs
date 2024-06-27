using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterProfessionalProfilesRequest
  {
    [ProtoMember(1)]
    public string Name { get; set; }

    [ProtoMember(2)]
    public string Email { get; set; }

    [ProtoMember(3)]
    public bool Disabled { get; set; }
  }
}
