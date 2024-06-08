using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetAssessmentsProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<AssessmentProfiles> Assessments { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class AssessmentProfiles
  {
    [DataMember(Order = 1)]
    public string AssessmentId { get; set; }

    [DataMember(Order = 2)]
    public string ProfessionalId { get; set; }

    [DataMember(Order = 3)]
    public string RoleId { get; set; }

    [DataMember(Order = 4)]
    public string SquadId { get; set; }
  }
}
