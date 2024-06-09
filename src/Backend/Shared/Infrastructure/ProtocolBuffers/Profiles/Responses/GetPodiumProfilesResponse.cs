using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetPodiumProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<PodiumProfiles> Podium { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class PodiumProfiles
  {
    [DataMember(Order = 1)]
    public required string PodiumId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required string Email { get; set; }

    [DataMember(Order = 4)]
    public required string Photo { get; set; }
  }
}
