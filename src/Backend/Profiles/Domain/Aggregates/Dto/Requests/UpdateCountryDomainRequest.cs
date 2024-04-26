using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests;

[DataContract]
public class UpdateCountryDomainRequest
{
    [DataMember(Order = 1)]
    public required string CountryId { get; init; }

    [DataMember(Order = 2)]
    public string? Name { get; init; }
}
