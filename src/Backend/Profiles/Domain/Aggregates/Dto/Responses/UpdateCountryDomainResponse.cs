using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Responses;

[DataContract]
public class UpdateCountryDomainResponse
{
    [DataMember(Order = 1)]
    public required string CountryId { get; init; }

    [DataMember(Order = 2)]
    public string Name { get; init; }

    [DataMember(Order = 3)]
    public bool Disabled { get; init; }
}
