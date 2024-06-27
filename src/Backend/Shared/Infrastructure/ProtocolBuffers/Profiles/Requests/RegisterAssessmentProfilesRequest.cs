using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterAssessmentProfilesRequest
  {
    [ProtoMember(1)]
    public string ProfessionalId { get; set; }

    [ProtoMember(2)]
    public string RoleId { get; set; }

    [ProtoMember(3)]
    public string SquadId { get; set; }
  }
}
