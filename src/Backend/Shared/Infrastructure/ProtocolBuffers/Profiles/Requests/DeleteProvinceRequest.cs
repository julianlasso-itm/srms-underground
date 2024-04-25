using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;

[DataContract]
public class DeleteProvinceRequest
{
    [DataMember(Order = 1)]
    public required string ProvinceId { get; set; }
}
