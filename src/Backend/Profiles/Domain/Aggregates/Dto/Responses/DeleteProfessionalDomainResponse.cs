using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class DeleteProfessionalDomainResponse
    {
        [DataMember(Order = 1)]
        public string ProfessionalId { get; set; }
    }
}
