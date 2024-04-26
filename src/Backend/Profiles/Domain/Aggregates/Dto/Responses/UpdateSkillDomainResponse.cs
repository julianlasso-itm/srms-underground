using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Responses
{
    [DataContract]
    public class UpdateSkillDomainResponse
    {
        [DataMember(Order = 1)]
        public string SkillId { get; internal set; }

        [DataMember(Order = 2)]
        public string Name { get; internal set; }

        [DataMember(Order = 3)]
        public bool Disabled { get; internal set; }
    }
}
