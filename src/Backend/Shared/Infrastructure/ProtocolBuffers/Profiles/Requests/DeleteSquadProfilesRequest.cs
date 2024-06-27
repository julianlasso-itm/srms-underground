using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteSquadProfilesRequest
  {
    [ProtoMember(1)]
    public required string SquadId { get; set; }
  }
}
