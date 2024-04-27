using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Responses
{
    [DataContract]
    public class RegisterSkillDomainResponse
    {
        [DataMember(Order = 1)]
        public required string SkillId { get; init; }

        [DataMember(Order = 2)]
        public string Name { get; init; }

        [DataMember(Order = 3)]
        public bool Disabled { get; init; }
    }
}
