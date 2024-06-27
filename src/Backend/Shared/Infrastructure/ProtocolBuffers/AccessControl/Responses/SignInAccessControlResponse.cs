using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class SignInAccessControlResponse
  {
    [ProtoMember(1)]
    public required string Token { get; set; }
  }
}
