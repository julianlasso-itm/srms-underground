using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

[DataContract]
public class DeleteRoleRequest
{
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }
}
