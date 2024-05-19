using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class RegisterUserRequest
  {
    [DataMember(Order = 1)]
    public required string Name { get; set; }

    [DataMember(Order = 2)]
    public required string Email { get; set; }

    [DataMember(Order = 3)]
    public required string Password { get; set; }

    [DataMember(Order = 4)]
    public required string Avatar { get; set; }

    [DataMember(Order = 5)]
    public required string AvatarExtension { get; set; }

    [DataMember(Order = 6)]
    public required string CityId { get; set; }
  }
}
