using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [DataContract]
  public class RegisterUserRequest
  {
    [FromForm(Name = "name")]
    [DataMember(Order = 1)]
    public required string Name { get; set; }

    [FromForm(Name = "email")]
    [DataMember(Order = 2)]
    public required string Email { get; set; }

    [FromForm(Name = "password")]
    [DataMember(Order = 3)]
    public required string Password { get; set; }

    [FromForm(Name = "avatar")]
    [DataMember(Order = 4)]
    public required IFormFile Avatar { get; set; }
  }
}
