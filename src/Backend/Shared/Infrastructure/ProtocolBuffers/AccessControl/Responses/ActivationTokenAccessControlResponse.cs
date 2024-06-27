using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class ActivationTokenAccessControlResponse
  {
    [ProtoMember(1)]
    public bool IsAuthorized { get; set; }
  }
}
