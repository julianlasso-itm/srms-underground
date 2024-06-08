using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class DeleteAssessmentProfilesRequest
  {
    [DataMember(Order = 1)]
    public required string AssessmentId { get; set; }
  }
}
