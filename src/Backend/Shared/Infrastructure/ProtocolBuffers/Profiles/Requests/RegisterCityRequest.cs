using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;

[DataContract]
public class RegisterCityRequest
{
    [DataMember(Order = 1)]
    public required string Name { get; set; }

    [DataMember(Order = 2)]
    public required string ProvinceId { get; set; }
}
