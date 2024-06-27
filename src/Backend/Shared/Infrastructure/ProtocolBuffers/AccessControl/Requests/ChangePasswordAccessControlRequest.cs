using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class ChangePasswordAccessControlRequest
  {
    [ProtoMember(1, IsRequired = false)]
    public string? UserId { get; set; }

    [ProtoMember(2)]
    public required string OldPassword { get; set; }

    [ProtoMember(3)]
    public required string NewPassword { get; set; }
  }
}
