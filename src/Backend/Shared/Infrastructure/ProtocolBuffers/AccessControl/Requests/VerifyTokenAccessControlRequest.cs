using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class VerifyTokenAccessControlRequest
  {
    [DataMember(Order = 1)]
    public required string Token { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? PrivateKeyPath { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? PublicKeyPath { get; set; }
  }
}
