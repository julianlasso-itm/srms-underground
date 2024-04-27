using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Responses
{
    [DataContract]
    public class DeleteSkillDomainResponse
    {
        [DataMember(Order = 1)]
        public string SkillId { get; set; }
    }
}
