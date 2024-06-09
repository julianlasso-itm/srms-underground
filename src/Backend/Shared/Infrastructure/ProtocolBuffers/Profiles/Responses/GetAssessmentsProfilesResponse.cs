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

    [DataMember(Order = 5)]
    public ProfessionalProfiles Professional { get; set; }

    [DataMember(Order = 6)]
    public RoleProfiles Role { get; set; }

    [DataMember(Order = 7)]
    public SquadProfiles Squad { get; set; }

    [DataMember(Order = 8)]
    public IEnumerable<SkillWithSubSkillsProfiles> Skills { get; set; }
  }

  [DataContract]
  public class SkillWithSubSkillsProfiles
  {
    [DataMember(Order = 1)]
    public required string SkillId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; set; }

    [DataMember(Order = 4)]
    public IEnumerable<SubSkillWithResultProfiles> SubSkills { get; set; }
  }

  [DataContract]
  public class SubSkillWithResultProfiles
  {
    [DataMember(Order = 1)]
    public required string SubSkillId { get; set; }

    [DataMember(Order = 2)]
    public required string SkillId { get; set; }

    [DataMember(Order = 3)]
    public required string Name { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }

    [DataMember(Order = 5)]
    public IEnumerable<ResultProfiles> Results { get; set; }
  }

  [DataContract]
  public class ResultProfiles
  {
    [DataMember(Order = 1)]
    public required string ResultId { get; set; }

    [DataMember(Order = 2)]
    public required string AssessmentId { get; set; }

    [DataMember(Order = 3)]
    public required string SubSkillId { get; set; }

    [DataMember(Order = 4)]
    public required int Result { get; set; }

    [DataMember(Order = 5)]
    public string? Comment { get; set; }

    [DataMember(Order = 6)]
    public required DateTime DateTime { get; set; }
  }
}
