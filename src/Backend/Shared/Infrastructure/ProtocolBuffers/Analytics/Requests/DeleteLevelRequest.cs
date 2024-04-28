using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;

[DataContract]
public class DeleteLevelSecurityRequest
{
    [DataMember(Order = 1)]
    public required string LevelId { get; set; }
}
