using System.Runtime.Serialization;

namespace Profiles.Domain.Aggregates.Dto.Requests;

[DataContract]
public class RegisterCountryDomainRequest
{
    [DataMember(Order =1)]
    public required string Name { get; init; }
}
