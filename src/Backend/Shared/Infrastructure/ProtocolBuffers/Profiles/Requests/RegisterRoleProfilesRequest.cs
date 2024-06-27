using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class RegisterRoleProfilesRequest
  {
    [ProtoMember(1)]
    public required string Name { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Description { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public IEnumerable<string>? Skills { get; set; }
  }
}
