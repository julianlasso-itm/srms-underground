using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class PasswordRecoveryAccessControlResponse
  {
    [DataMember(Order = 1)]
    public bool Success { get; set; }
  }
}
