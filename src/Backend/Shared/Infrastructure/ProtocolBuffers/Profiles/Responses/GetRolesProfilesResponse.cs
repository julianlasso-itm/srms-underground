using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetRolesProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<RoleProfiles> Roles { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class RoleProfiles
  {
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? Description { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }

    [DataMember(Order = 5)]
    public required IEnumerable<SkillProfiles> Skills { get; set; }
  }
}
