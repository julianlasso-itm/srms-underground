using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class UpdateAssessmentProfilesRequest
  {
    [ProtoMember(1, IsRequired = false)]
    public string? AssessmentId { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? ProfessionalId { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? RoleId { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public string? SquadId { get; set; }
  }
}
