using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteCountryProfilesResponse
  {
    [ProtoMember(1)]
    public required string CountryId { get; set; }
  }
}
