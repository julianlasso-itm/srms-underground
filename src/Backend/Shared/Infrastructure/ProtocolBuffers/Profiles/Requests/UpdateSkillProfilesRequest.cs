using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class UpdateSkillProfilesRequest
  {
    [ProtoMember(1, IsRequired = false)]
    public string? SkillId { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? Name { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public bool? Disable { get; set; }
  }
}
