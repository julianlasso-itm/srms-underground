using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class PasswordRecoveryAccessControlResponse
  {
    [ProtoMember(1)]
    public bool Success { get; set; }
  }
}
