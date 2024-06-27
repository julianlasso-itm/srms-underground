using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class UpdateCityProfilesRequest
  {
    [ProtoMember(1, IsRequired = false)]
    public string? CityId { get; set; }

    [ProtoMember(2, IsRequired = false)]
    public string? ProvinceId { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Name { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public bool? Disable { get; set; }
  }
}
