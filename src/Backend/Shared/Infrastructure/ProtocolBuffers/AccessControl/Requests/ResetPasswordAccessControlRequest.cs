using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class ResetPasswordAccessControlRequest
  {
    [DataMember(Order = 1)]
    public required string Token { get; set; }

    [DataMember(Order = 2)]
    public required string Password { get; set; }
  }
}
