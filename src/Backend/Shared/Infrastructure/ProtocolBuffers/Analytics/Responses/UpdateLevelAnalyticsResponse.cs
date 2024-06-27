using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Responses
{
  [ProtoContract]
  public class UpdateLevelAnalyticsResponse
  {
    [ProtoMember(1)]
    public required string LevelId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public string? Description { get; set; }

    [ProtoMember(4)]
    public bool? Disabled { get; set; }
  }
}
