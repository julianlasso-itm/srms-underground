using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Responses
{
  [DataContract]
  public class UpdateLevelSecurityResponse
  {
    [DataMember(Order = 1)]
    public required string LevelId { get; set; }

    [DataMember(Order = 2)]
    public string? Name { get; set; }

    [DataMember(Order = 3)]
    public string? Description { get; set; }

    [DataMember(Order = 4)]
    public bool? Disabled { get; set; }
  }
}
