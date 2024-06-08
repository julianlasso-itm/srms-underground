using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class DeleteSquadProfilesRequest
  {
    [DataMember(Order = 1)]
    public required string SquadId { get; set; }
  }
}
