using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

[DataContract]
public class RegisterRoleSecurityRequest
{
    [DataMember(Order = 1)]
    public required string Name { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? Description { get; set; }
}
