using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class DeleteProfessionalDomainRequest
    {
        [DataMember(Order = 1)]
        public required string ProfessionalId { get; set; }
    }
}
