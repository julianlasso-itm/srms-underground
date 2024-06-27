using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateCityProfilesResponse
  {
    [ProtoMember(1)]
    public required string CityId { get; set; }

    [ProtoMember(2)]
    public string? ProvinceId { get; set; }

    [ProtoMember(3)]
    public string? Name { get; set; }

    [ProtoMember(4)]
    public bool? Disabled { get; set; }
  }
}
