using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetSquadsProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<SquadProfiles> Squads { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class SquadProfiles
  {
    [ProtoMember(1)]
    public string SquadId { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public bool Disabled { get; set; }
  }
}
