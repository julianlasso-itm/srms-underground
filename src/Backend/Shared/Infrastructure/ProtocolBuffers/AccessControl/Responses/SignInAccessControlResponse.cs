using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class SignInAccessControlResponse
  {
    [DataMember(Order = 1)]
    public required string Token { get; set; }
  }
}
