using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class VerifyTokenAccessControlResponse
  {
    [ProtoMember(1)]
    public required string UserId { get; set; }

    [ProtoMember(2)]
    public required string Email { get; set; }

    [ProtoMember(3)]
    public required string Photo { get; set; }

    [ProtoMember(4)]
    public required List<string> Roles { get; set; }
  }
}
