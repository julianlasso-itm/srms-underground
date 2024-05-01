using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class UpdateProfessionalProfilesRequest
  {
    [DataMember(Order = 1, IsRequired = false)]
    public string? ProfessionalId { get; set; }

    [DataMember(Order = 2, IsRequired = false)]
    public string Name { get; set; }

    [DataMember(Order = 3, IsRequired = false)]
    public string Email { get; set; }

    [DataMember(Order = 4, IsRequired = false)]
    public bool Disable { get; set; }
  }
}
