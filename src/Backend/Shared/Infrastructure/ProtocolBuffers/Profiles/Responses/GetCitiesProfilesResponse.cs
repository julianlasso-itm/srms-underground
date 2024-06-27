using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetCitiesProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<CityProfiles> Cities { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class CityProfiles
  {
    [ProtoMember(1)]
    public required string CityId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3)]
    public required string ProvinceId { get; set; }

    [ProtoMember(4)]
    public required bool Disabled { get; set; }

    [ProtoMember(5)]
    public required ProvinceProfiles Province { get; set; }
  }
}
