using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class RegisterSkillDomainRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; init; }

    }
}
