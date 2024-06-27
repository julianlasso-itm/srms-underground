using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateAssessmentProfilesResponse
  {
    [ProtoMember(1)]
    public string AssessmentId { get; set; }

    [ProtoMember(2)]
    public string? ProfessionalId { get; set; }

    [ProtoMember(3)]
    public string? RoleId { get; set; }

    [ProtoMember(4)]
    public string? SquadId { get; set; }
  }
}
