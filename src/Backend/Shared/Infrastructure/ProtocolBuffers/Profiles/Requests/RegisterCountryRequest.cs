using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;

[DataContract]
public class RegisterCountryRequest
{
    [DataMember(Order = 1)]
    public required string Name { get; set; }
}
