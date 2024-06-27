using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class RegisterProvinceProfilesResponse
  {
    [ProtoMember(1)]
    public required string ProvinceId { get; set; }

    [ProtoMember(2)]
    public required string CountryId { get; set; }

    [ProtoMember(3)]
    public required string Name { get; set; }

    [ProtoMember(4)]
    public required bool Disabled { get; set; }
  }
}
