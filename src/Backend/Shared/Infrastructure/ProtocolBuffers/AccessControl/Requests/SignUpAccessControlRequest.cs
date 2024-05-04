using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class SignUpAccessControlRequest
  {
    [DataMember(Order = 1)]
    public required string Email { get; set; }

    [DataMember(Order = 2)]
    public required string Password { get; set; }

    [DataMember(Order = 3)]
    public required string FullName { get; set; }

    [DataMember(Order = 5)]
    public required bool Gender { get; set; }
  }
}
