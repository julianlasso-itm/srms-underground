using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class GetProfessionalsProfilesRequest
  {
    [ProtoMember(1)]
    public int Page { get; set; }

    [ProtoMember(2)]
    public int Limit { get; set; }

    [ProtoMember(3, IsRequired = false)]
    public string? Filter { get; set; }

    [ProtoMember(4, IsRequired = false)]
    public string? FilterBy { get; set; }

    [ProtoMember(5, IsRequired = false)]
    public string? Sort { get; set; }

    [ProtoMember(6, IsRequired = false)]
    public string? Order { get; set; } = "asc";
  }
}
