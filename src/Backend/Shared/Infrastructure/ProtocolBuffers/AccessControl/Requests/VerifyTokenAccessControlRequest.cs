using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class VerifyTokenAccessControlRequest
  {
    [ProtoMember(1)]
    public required string Token { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? PrivateKeyPath { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? PublicKeyPath { get; set; }
  }
}
