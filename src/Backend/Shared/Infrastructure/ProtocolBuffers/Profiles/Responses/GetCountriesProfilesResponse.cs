using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class GetCountriesProfilesResponse
  {
    [ProtoMember(1)]
    public required IEnumerable<CountryProfiles> Countries { get; set; }

    [ProtoMember(2)]
    public required int Total { get; set; }
  }

  [ProtoContract]
  public class CountryProfiles
  {
    [ProtoMember(1)]
    public required string CountryId { get; set; }

    [ProtoMember(2)]
    public required string Name { get; set; }

    [ProtoMember(3)]
    public required bool Disabled { get; set; }
  }
}
