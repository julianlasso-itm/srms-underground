using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class DeleteSquadProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string SquadId { get; set; }
  }
}
