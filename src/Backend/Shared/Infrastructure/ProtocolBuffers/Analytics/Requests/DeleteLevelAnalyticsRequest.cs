using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Requests
{
  [DataContract]
  public class DeleteLevelAnalyticsRequest
  {
    [DataMember(Order = 1)]
    public required string LevelId { get; set; }
  }
}
