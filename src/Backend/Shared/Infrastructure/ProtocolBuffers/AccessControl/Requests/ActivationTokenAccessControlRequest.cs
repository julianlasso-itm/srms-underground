using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class ActivationTokenAccessControlRequest
  {
    [ProtoMember(1)]
    public required string ActivationToken { get; set; }
  }
}
