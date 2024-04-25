using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

[DataContract]
public class DeleteProvinceResponse
{
    [DataMember(Order = 1)]
    public required string ProvinceId { get; set; }
}
