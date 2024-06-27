using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class RegisterSquadProfilesResponse
  {
    [ProtoMember(1)]
    public required string SquadId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3)]
    public required bool Disabled { get; set; }
  }
}
