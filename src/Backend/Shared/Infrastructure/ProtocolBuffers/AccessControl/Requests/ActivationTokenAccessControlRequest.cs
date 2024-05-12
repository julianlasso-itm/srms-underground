using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class ActivationTokenAccessControlRequest {
    [DataMember(Order = 1)]
    public required string ActivationToken { get; set; }
  }
}
