using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [ProtoContract]
  public class RegisterUserRequest
  {
    [ProtoMember(1)]
    public required string Name { get; set; }

    [ProtoMember(2)]
    public required string Email { get; set; }

    [ProtoMember(3)]
    public required string Password { get; set; }

    [ProtoMember(4)]
    public required string Avatar { get; set; }

    [ProtoMember(5)]
    public required string AvatarExtension { get; set; }

    [ProtoMember(6)]
    public required string CityId { get; set; }
  }
}
