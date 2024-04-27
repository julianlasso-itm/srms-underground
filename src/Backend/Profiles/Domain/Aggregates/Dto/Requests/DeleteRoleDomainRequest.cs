using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class DeleteRoleDomainRequest
    {
        [DataMember(Order = 1)]
        public required string RoleId { get; init; }
    }
}
