using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class SignInAccessControlRequest
  {
    [DataMember(Order = 1)]
    public required string Email { get; set; }

    [DataMember(Order = 2)]
    public required string Password { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? PrivateKeyPath { get; set; }

    [DataMember(Order = 4, IsRequired = false)]
    public string? PublicKeyPath { get; set; }
  }
}
