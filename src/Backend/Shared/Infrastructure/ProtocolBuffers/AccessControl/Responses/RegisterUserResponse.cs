using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

[DataContract]
public class RegisterUserResponse
{
    [DataMember(Order = 1)]
    public required string UserId { get; set; }

    [DataMember(Order = 2)]
    public required string Email { get; set; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; set; }
}
