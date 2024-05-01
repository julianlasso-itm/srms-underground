using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class RegisterRoleProfilesRequest
  {
    [DataMember(Order = 1)]
    public required string Name { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? Description { get; set; }
  }
}
