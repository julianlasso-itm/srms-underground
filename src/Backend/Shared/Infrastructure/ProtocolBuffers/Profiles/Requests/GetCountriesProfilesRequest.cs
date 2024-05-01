using System.Runtime.Serialization;
using Infrastructure.ProtocolBuffers.Base;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class GetCountriesProfilesRequest : BaseGetRequest { }
}
