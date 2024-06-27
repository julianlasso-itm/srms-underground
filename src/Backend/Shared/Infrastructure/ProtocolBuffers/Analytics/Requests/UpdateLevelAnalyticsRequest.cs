using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Requests
{
  [ProtoContract]
  public class UpdateLevelAnalyticsRequest
  {
    [ProtoMember(1, IsRequired = false)]
    public string? LevelId { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Description { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public bool? Disable { get; set; }
  }
}
