using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

[DataContract]
public class GetCitiesResponse
{
    [DataMember(Order = 1)]
    public required IEnumerable<City> Cities { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
}

[DataContract]
public class City
{
    [DataMember(Order = 1)]
    public required string CityId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required string ProvinceId { get; set; }

    [DataMember(Order = 4)]
    public required bool Disabled { get; set; }

    [DataMember(Order = 5)]
    public required Province Province { get; set; }
}
