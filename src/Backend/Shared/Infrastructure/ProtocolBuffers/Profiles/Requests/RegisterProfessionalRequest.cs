using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class RegisterProfessionalRequest
  {
    [DataMember(Order = 1)]
    public string Name { get; set; }

    [DataMember(Order = 2)]
    public string Email { get; set; }

    [DataMember(Order = 3)]
    public bool Disabled { get; set; }
  }
}
