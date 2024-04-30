using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics.Responses
{
  [DataContract]
  public class DeleteLevelSecurityResponse
  {
    [DataMember(Order = 1)]
    public required string LevelId { get; set; }
  }
}
