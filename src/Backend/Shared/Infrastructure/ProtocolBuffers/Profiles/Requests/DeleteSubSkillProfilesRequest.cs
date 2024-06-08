using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class DeleteSubSkillProfilesRequest
  {
    [DataMember(Order = 1)]
    public required string SubSkillId { get; set; }
  }
}
