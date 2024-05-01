using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class DeleteRoleProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }
  }
}
