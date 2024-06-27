using ProtoBuf;

namespace Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class ResetPasswordAccessControlResponse
  {
    [ProtoMember(1)]
    public bool Success { get; set; }
  }
}
