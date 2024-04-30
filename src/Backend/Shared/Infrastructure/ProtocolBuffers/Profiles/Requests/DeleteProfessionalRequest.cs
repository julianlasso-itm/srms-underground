using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
  [DataContract]
  public class DeleteProfessionalRequest
  {
    [DataMember(Order = 1)]
    public required string ProfessionalId { get; set; }
  }
}
