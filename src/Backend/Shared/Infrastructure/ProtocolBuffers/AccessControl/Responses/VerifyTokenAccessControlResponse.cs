using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class VerifyTokenAccessControlResponse
  {
    [DataMember(Order = 1)]
    public required string UserId { get; set; }

    [DataMember(Order = 2)]
    public required string Email { get; set; }

    [DataMember(Order = 3)]
    public required string Photo { get; set; }

    [DataMember(Order = 4)]
    public required List<string> Roles { get; set; }
  }
}
