using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetSquadsProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<SquadProfiles> Squads { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class SquadProfiles
  {
    [DataMember(Order = 1)]
    public required string SquadId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; set; }
  }
}
