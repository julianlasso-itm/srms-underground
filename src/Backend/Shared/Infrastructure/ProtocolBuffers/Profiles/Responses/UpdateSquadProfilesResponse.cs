using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateSquadProfilesResponse
  {
    [ProtoMember(1)]
    public required string SquadId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public bool? Disabled { get; set; }
  }
}
