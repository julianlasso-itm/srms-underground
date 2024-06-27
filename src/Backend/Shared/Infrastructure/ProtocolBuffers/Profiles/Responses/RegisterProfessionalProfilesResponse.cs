using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class RegisterProfessionalProfilesResponse
  {
    [ProtoMember(1)]
    public required string Name { get; set; }

    [ProtoMember(2)]
    public required string Email { get; set; }

    [ProtoMember(3)]
    public required bool Disabled { get; set; }
  }
}
