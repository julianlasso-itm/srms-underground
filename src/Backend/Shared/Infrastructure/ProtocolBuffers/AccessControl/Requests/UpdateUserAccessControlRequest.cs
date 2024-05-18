using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class UpdateUserAccessControlRequest
  {
    [DataMember(Order = 1)]
    public required string UserId { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? Name { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? Avatar { get; set; }

    [DataMember(Order = 4, IsRequired = false)]
    public string? AvatarExtension { get; set; }

    [DataMember(Order = 5, IsRequired = false)]
    public bool? Disabled { get; set; }
  }
}
