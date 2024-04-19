using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

[DataContract]
public class UpdateRoleRequest
{
    [DataMember(Order = 1, IsRequired = false)]
    public string? RoleId { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? Name { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? Description { get; set; }

    [DataMember(Order = 4, IsRequired = false)]
    public bool? Disable { get; set; }
}
