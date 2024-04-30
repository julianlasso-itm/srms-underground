using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class GetRolesSecurityResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<RoleSecurity> Roles { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class RoleSecurity
  {
    [DataMember(Order = 1)]
    public required string RoleId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? Description { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }
  }
}
