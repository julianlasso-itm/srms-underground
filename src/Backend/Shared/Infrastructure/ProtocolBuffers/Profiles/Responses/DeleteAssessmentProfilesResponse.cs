using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class DeleteAssessmentProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string AssessmentId { get; set; }
  }
}
