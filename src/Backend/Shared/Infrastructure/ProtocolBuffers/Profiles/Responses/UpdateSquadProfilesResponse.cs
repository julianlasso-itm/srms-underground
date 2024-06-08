using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class UpdateSquadProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string SquadId { get; set; }

    [DataMember(Order = 2)]
    public string? Name { get; set; }

    [DataMember(Order = 3)]
    public bool? Disabled { get; set; }
  }
}
