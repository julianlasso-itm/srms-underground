using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetAssessmentsProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<AssessmentProfiles> Assessments { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class AssessmentProfiles
  {
    [ProtoMember(1)]
    public string AssessmentId { get; set; }

    [ProtoMember(2)]
    public string ProfessionalId { get; set; }

    [ProtoMember(3)]
    public string RoleId { get; set; }

    [ProtoMember(4)]
    public string SquadId { get; set; }

    [ProtoMember(5)]
    public ProfessionalProfiles Professional { get; set; }

    [ProtoMember(6)]
    public RoleProfiles Role { get; set; }

    [ProtoMember(7)]
    public SquadProfiles Squad { get; set; }

    [ProtoMember(8)]
    public IEnumerable<SkillWithSubSkillsProfiles> Skills { get; set; }
  }

  [ProtoContract]
  public class SkillWithSubSkillsProfiles
  {
    [ProtoMember(1)]
    public required string SkillId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3)]
    public required bool Disabled { get; set; }

    [ProtoMember(4)]
    public IEnumerable<SubSkillWithResultProfiles> SubSkills { get; set; }
  }

  [ProtoContract]
  public class SubSkillWithResultProfiles
  {
    [ProtoMember(1)]
    public required string SubSkillId { get; set; }

    [ProtoMember(2)]
    public required string SkillId { get; set; }

    [ProtoMember(3)]
    public required string Name { get; set; }

    [ProtoMember(4)]
    public required bool Disabled { get; set; }

    [ProtoMember(5)]
    public IEnumerable<ResultProfiles> Results { get; set; }
  }

  [ProtoContract]
  public class ResultProfiles
  {
    [ProtoMember(1)]
    public required string ResultId { get; set; }

    [ProtoMember(2)]
    public required string AssessmentId { get; set; }

    [ProtoMember(3)]
    public required string SubSkillId { get; set; }

    [ProtoMember(4)]
    public required int Result { get; set; }

    [ProtoMember(5)]
    public string? Comment { get; set; }

    [ProtoMember(6)]
    public required DateTime DateTime { get; set; }
  }
}
