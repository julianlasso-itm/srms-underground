using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class UpdateSkillProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string SkillId { get; set; }

    [DataMember(Order = 2)]
    public string? Name { get; set; }

    [DataMember(Order = 3)]
    public bool? Disabled { get; set; }
  }
}
