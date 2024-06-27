using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [ProtoContract]
  public class DeleteCountryProfilesRequest
  {
    [ProtoMember(1)]
    public required string CountryId { get; set; }
  }
}
