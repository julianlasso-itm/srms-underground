using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests;

[DataContract]
public class DeleteCountryDomainRequest
{
    [DataMember(Order = 1)]
    public string CountryId { get; init; }
}
