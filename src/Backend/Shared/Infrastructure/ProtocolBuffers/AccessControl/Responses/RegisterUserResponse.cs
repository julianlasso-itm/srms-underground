using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class RegisterUserResponse
  {
    [ProtoMember(1)]
    public required bool Success { get; set; }
  }
}
