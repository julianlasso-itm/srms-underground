using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class DeleteRoleAccessControlRequest
  {
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }
  }
}
