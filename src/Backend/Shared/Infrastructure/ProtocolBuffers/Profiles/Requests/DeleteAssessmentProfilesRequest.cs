using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteAssessmentProfilesRequest
  {
    [ProtoMember(1)]
    public required string AssessmentId { get; set; }
  }
}
