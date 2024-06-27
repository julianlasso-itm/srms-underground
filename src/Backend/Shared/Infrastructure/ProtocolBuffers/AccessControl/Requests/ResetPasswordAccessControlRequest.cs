using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class ResetPasswordAccessControlRequest
  {
    [ProtoMember(1)]
    public required string Token { get; set; }

    [ProtoMember(2)]
    public required string Password { get; set; }
  }
}
