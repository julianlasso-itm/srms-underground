using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class UpdateUserAccessControlResponse
  {
    [DataMember(Order = 1)]
    public required string UserId { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string? Name { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string? Photo { get; set; }

    [DataMember(Order = 4, IsRequired = false)]
    public bool? Disabled { get; set; }
  }
}
