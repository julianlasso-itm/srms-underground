using System.Runtime.Serialization;

namespace Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class ResetPasswordAccessControlResponse
  {
    [DataMember(Order = 1)]
    public bool Success { get; set; }
  }
}
