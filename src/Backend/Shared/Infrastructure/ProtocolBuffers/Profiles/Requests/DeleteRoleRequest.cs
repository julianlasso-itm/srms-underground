using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;

[DataContract]
public class DeleteRoleRequest
{
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }
}
