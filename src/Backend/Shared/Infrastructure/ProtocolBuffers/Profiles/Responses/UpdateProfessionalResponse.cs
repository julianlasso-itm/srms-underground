using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class UpdateProfessionalResponse
  {
    [DataMember(Order = 1)]
    public required string ProfessionalId { get; set; }

    [DataMember(Order = 2)]
    public string? Name { get; set; }

    [DataMember(Order = 3)]
    public string? Email { get; set; }

    [DataMember(Order = 4)]
    public bool? Disabled { get; set; }
  }
}
