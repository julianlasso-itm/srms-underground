using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Responses;

[DataContract]
public class DeleteCountryDomainResponse
{
    [DataMember(Order = 1)]
    public string CountryId { get; init; }
}
