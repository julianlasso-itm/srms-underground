using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class ChangePasswordAccessControlResponse
  {
    [ProtoMember(1)]
    public required bool Success { get; set; }
  }
}
