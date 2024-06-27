using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteAssessmentProfilesResponse
  {
    [ProtoMember(1)]
    public required string AssessmentId { get; set; }
  }
}
