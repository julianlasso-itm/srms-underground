using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

[DataContract]
public class DeleteRoleSecurityRequest
{
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }
}
