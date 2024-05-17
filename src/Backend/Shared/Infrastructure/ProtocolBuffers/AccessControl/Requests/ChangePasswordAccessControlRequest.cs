using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class ChangePasswordAccessControlRequest
  {
    [DataMember(Order = 1, IsRequired = false)]
    public string? UserId { get; set; }

    [DataMember(Order = 2)]
    public required string OldPassword { get; set; }

    [DataMember(Order = 3)]
    public required string NewPassword { get; set; }
  }
}
