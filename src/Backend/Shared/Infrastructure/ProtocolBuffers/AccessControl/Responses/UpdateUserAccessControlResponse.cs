using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [ProtoContract]
  public class UpdateUserAccessControlResponse
  {
    [ProtoMember(1)]
    public required string UserId { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Photo { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public bool? Disabled { get; set; }
  }
}
