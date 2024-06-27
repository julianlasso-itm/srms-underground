using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Requests
{
  [ProtoContract]
  public class DeleteLevelAnalyticsRequest
  {
    [ProtoMember(1)]
    public required string LevelId { get; set; }
  }
}
