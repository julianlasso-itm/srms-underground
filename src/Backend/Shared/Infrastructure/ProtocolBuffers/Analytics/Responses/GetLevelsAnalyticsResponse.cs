using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Responses
{
  [ProtoContract]
  public class GetLevelsAnalyticsResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<LevelAnalytics> Levels { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class LevelAnalytics
  {
    [ProtoMember(1)]
    public required string LevelId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Description { get; set; }

    [ProtoMember(4)]
    public required bool Disabled { get; set; }
  }
}
