using System.Runtime.Serialization;
using Shared.Infrastructure.ProtocolBuffers.Interfaces;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses
{
  [DataContract]
  public class ResultRegisterUser // : IResultProtoBuf<RegisterUserResponse>
  {
    [DataMember(Order = 1)]
    public RegisterUserResponse Data { get; init; }

    [DataMember(Order = 2)]
    public bool Success { get; init; } = true;

    [DataMember(Order = 3)]
    public bool IsFailure => !Success;

    [DataMember(Order = 4, IsRequired = false)]
    public string? ErrorCode { get; init; }

    [DataMember(Order = 5, IsRequired = false)]
    public string? ErrorMessage { get; init; }

    [DataMember(Order = 6, IsRequired = false)]
    public string? ErrorDetails { get; init; }
  }

  [DataContract]
  public class RegisterUserResponse
  {
    [DataMember(Order = 1)]
    public required bool Success { get; set; }
  }
}
