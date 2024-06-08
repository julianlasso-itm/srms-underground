using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class RegisterAssessmentProfilesRequest
  {
    [DataMember(Order = 1)]
    public string ProfessionalId { get; set; }

    [DataMember(Order = 2)]
    public string RoleId { get; set; }

    [DataMember(Order = 3)]
    public string SquadId { get; set; }
  }
}
