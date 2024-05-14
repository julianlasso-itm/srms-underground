using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class RegisterUserResponse
  {
    [DataMember(Order = 1)]
    public required bool Success { get; set; }
  }
}
