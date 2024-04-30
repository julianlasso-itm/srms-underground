using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class UpdateCityResponse
  {
    [DataMember(Order = 1)]
    public required string CityId { get; set; }

    [DataMember(Order = 2)]
    public string? ProvinceId { get; set; }

    [DataMember(Order = 3)]
    public string? Name { get; set; }

    [DataMember(Order = 4)]
    public bool? Disabled { get; set; }
  }
}
