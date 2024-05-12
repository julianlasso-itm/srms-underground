using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class ActivationTokenAccessControlResponse
  {
    [DataMember(Order = 1)]
    public bool IsAuthorized { get; set; }
  }
}
