using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class UpdateProfessionalDomainRequest
    {
        [DataMember(Order = 1)]
        public required string ProfessionalId { get; set; }

        [DataMember(Order = 2)]
        public string? Name { get; set; }

        [DataMember(Order = 3)]
        public bool? Disabled { get; set; }

        [DataMember(Order = 4)]
        public required string Email { get; set; }
    }
}
