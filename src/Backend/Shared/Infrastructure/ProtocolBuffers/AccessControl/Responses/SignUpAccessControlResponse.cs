using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class SignUpAccessControlResponse
  {
    [DataMember(Order = 1)]
    public required string Message { get; set; }
  }
}
