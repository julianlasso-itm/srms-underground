using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteSquadProfilesResponse
  {
    [ProtoMember(1)]
    public required string SquadId { get; set; }
  }
}
