using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class PasswordRecoveryStepOneAccessControlResponse
  {
    [DataMember(Order = 1)]
    public required string Message { get; set; }
  }
}
