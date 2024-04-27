using System.Runtime.Serialization;

namespace AccessControl.Domain.Aggregates.Dto.Requests;

[DataContract]
public class DeleteRoleDomainRequest
{
    [DataMember]
    public required string RoleId { get; init; }
}
