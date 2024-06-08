using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetSubSkillsProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<SubSkillProfiles> SubSkills { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class SubSkillProfiles
  {
    [DataMember(Order = 1)]
    public required string SubSkillId { get; set; }

    [DataMember(Order = 2)]
    public required string SkillId { get; set; }

    [DataMember(Order = 3)]
    public required string Name { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }
  }
}
