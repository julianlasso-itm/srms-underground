using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class UpdateAssessmentProfilesRequest
  {
    [DataMember(Order = 1, IsRequired = false)]
    public string? AssessmentId { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? ProfessionalId { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? RoleId { get; set; }

    [DataMember(Order = 4, IsRequired = false)]
    public string? SquadId { get; set; }
  }
}
