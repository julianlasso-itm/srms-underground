using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateProfessionalProfilesResponse
  {
    [ProtoMember(1)]
    public required string ProfessionalId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public string? Email { get; set; }

    [ProtoMember(4)]
    public bool? Disabled { get; set; }
  }
}
