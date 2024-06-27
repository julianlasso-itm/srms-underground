using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteRoleProfilesResponse
  {
    [ProtoMember(1)]
    public required string RoleId { get; set; }
  }
}
