using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Responses
{
  [ProtoContract]
  public class DeleteLevelAnalyticsResponse
  {
    [ProtoMember(1)]
    public required string LevelId { get; set; }
  }
}
