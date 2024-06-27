using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteProfessionalProfilesRequest
  {
    [ProtoMember(1)]
    public required string ProfessionalId { get; set; }
  }
}
