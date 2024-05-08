using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class RegisterUserHelper : BaseHelperServiceInfrastructure
{
  public static async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request)
  {
    var command = AclInputMapper.ToRegisterUserCommand(request); // MapToRegisterUserCommand(request);
    var data = await Application.RegisterUser(command);
    return AclOutputMapper.ToRegisterUserResponse(data); // MapToRegisterUserResponse(data);
  }

  // private static RegisterUserCommand MapToRegisterUserCommand(RegisterUserRequest request)
  // {
  //   return new RegisterUserCommand
  //   {
  //     Name = request.Name,
  //     Email = request.Email,
  //     Password = request.Password,
  //     Avatar = request.Avatar,
  //   };
  // }

  // private static RegisterUserResponse MapToRegisterUserResponse(
  //   RegisterUserApplicationResponse data
  // )
  // {
  //   return new RegisterUserResponse
  //   {
  //     UserId = data.UserId,
  //     Email = data.Email,
  //     Disabled = data.Disabled,
  //   };
  // }
}
