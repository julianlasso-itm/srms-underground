using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class DeleteSubSkillProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string SubSkillId { get; set; }
  }
}
