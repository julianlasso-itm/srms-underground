using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

[DataContract]
public class DeleteRoleResponse
{
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }
}
