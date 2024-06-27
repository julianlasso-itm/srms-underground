using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class UpdateUserAccessControlRequest
  {
    [ProtoMember(1)]
    public required string UserId { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Avatar { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public string? AvatarExtension { get; set; }

    [ProtoMember(5, IsRequired = false)]
    public string? OldPhoto { get; set; }

    [ProtoMember(6, IsRequired = false)]
    public bool? Disabled { get; set; }

    [ProtoMember(7, IsRequired = false)]
    public string? CityId { get; set; }
  }
}
