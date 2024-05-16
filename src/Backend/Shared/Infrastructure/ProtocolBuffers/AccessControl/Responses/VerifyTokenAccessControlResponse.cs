using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class VerifyTokenAccessControlResponse
  {
    [DataMember(Order = 1)]
    public required List<string> Roles { get; set; }
  }
}
