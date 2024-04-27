using System.Runtime.Serialization;
using Profiles.Domain.Entities.Structs;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class RegisterProfessionalDomainResponse
    {
        [DataMember(Order = 1)]
        public string ProfessionalId { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Email { get; set; }

        [DataMember(Order = 4)]
        public bool Disabled { get; set; }

        [DataMember(Order = 5)]
        public IEnumerable<SkillStruct> Skills { get; internal set; }
    }
}
