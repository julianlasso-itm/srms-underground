using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class UpdateRoleProfilesRequest
  {
    [ProtoMember(1, IsRequired = false)]
    public string? RoleId { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Description { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public bool? Disable { get; set; }

    [ProtoMember(5, IsRequired = false)]
    public IEnumerable<string>? Skills { get; set; }
  }
}
