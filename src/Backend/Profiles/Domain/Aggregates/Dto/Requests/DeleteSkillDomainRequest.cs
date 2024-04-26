using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class DeleteSkillDomainRequest
    {
        [DataMember(Order = 1)]
        public required string SkillId { get; set; }
    }
}
