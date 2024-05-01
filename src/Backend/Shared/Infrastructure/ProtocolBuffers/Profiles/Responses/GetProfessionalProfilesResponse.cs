using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetProfessionalProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<ProfessionalProfiles> Professionals { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class ProfessionalProfiles
  {
    [DataMember(Order = 1)]
    public string ProfessionalId { get; set; }

    [DataMember(Order = 2)]
    public string Name { get; set; }

    [DataMember(Order = 3)]
    public string Email { get; set; }

    [DataMember(Order = 4)]
    public bool Disabled { get; set; }
  }
}
