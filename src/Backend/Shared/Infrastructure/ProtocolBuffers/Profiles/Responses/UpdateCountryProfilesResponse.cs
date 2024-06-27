using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateCountryProfilesResponse
  {
    [ProtoMember(1)]
    public required string CountryId { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public bool? Disabled { get; set; }
  }
}
