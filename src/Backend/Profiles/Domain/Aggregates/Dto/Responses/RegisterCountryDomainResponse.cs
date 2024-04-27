using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Responses;

[DataContract]
public class RegisterCountryDomainResponse
{
    [DataMember(Order = 1)]
    public required string CountryId { get; init; }

    [DataMember(Order = 2)]
    public required string Name { get; init; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; init; }
}
