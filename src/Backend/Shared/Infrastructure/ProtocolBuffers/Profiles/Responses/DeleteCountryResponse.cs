using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

[DataContract]
public class DeleteCountryResponse
{
    [DataMember(Order = 1)]
    public required string CountryId { get; set; }
}
