using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class UpdateProvinceProfilesResponse
  {
    [ProtoMember(1)]
    public required string ProvinceId { get; set; }

    [ProtoMember(2)]
    public string? CountryId { get; set; }

    [ProtoMember(3)]
    public string? Name { get; set; }

    [ProtoMember(4)]
    public bool? Disabled { get; set; }
  }
}
