using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class RegisterCityProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string CityId { get; set; }

    [DataMember(Order = 2)]
    public required string ProvinceId { get; set; }

    [DataMember(Order = 3)]
    public required string Name { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }
  }
}
