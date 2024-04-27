using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
    [DataContract]
    public class GetProfessionalResponse
    {
        [DataMember(Order = 1)]
        public required IEnumerable<ProfessionalContract> Professionals { get; set; }

        [DataMember(Order = 2)]
        public required int Total { get; set; }
    }

    [DataContract]
    public class ProfessionalContract
    {
        [DataMember(Order = 1)]
        public string ProfessionalId { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Email { get; set; }

        [DataMember(Order = 4)]
        public IEnumerable<SkillContract> Skills { get; set; }

        [DataMember(Order = 5)]
        public bool Disabled { get; set; }
    }
}
