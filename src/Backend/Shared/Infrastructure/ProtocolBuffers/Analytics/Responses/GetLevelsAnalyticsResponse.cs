using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Responses
{
  [DataContract]
  public class GetLevelsAnalyticsResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<LevelAnalytics> Levels { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class LevelAnalytics
  {
    [DataMember(Order = 1)]
    public required string LevelId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? Description { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }
  }
}
