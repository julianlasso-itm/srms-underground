using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class PasswordRecoveryStepOneAccessControlRequest
  {
    [DataMember(Order = 1)]
    public required string Email { get; set; }
  }
}
