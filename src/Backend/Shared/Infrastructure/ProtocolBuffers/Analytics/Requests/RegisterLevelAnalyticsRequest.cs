using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Requests
{
  [ProtoContract]
  public class RegisterLevelAnalyticsRequest
  {
    [ProtoMember(1)]
    public required string Name { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Description { get; set; }
  }
}
