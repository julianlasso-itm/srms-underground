using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class SignInAccessControlRequest
  {
    [ProtoMember(1)]
    public required string Email { get; set; }

    [ProtoMember(2)]
    public required string Password { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? PrivateKeyPath { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public string? PublicKeyPath { get; set; }
  }
}
