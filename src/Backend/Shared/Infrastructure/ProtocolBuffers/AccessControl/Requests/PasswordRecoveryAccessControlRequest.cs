using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class PasswordRecoveryAccessControlRequest
  {
    [ProtoMember(1)]
    public string Email { get; set; }
  }
}
