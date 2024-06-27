using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetProfessionalProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<ProfessionalProfiles> Professionals { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class ProfessionalProfiles
  {
    [ProtoMember(1)]
    public string ProfessionalId { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public string Email { get; set; }

    [ProtoMember(4)]
    public bool Disabled { get; set; }
  }
}
