using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class PasswordRecoveryAccessControlRequest
  {
    [DataMember(Order = 1)]
    public string Email { get; set; }
  }
}
