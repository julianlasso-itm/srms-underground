using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class RegisterSquadProfilesRequest
  {
    [DataMember(Order = 1)]
    public string Name { get; set; }
  }
}
