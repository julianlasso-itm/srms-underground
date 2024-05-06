using AccessControl.Application.Commands;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal static class RegisterUserHelper
{
  private static IApplication<UserModel, RoleModel> s_application;

  public static void SetApplication(IApplication<UserModel, RoleModel> application)
  {
    s_application = application;
  }

  public static async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request)
  {
    var newUserCommand = MapToRegisterUserCommand(request);
    var data = await s_application.RegisterUser(newUserCommand);
    return MapToRegisterUserResponse(data);
  }

  private static RegisterUserCommand MapToRegisterUserCommand(RegisterUserRequest request)
  {
    return new RegisterUserCommand { Email = request.Email, Password = request.Password, };
  }

  private static RegisterUserResponse MapToRegisterUserResponse(
    RegisterUserApplicationResponse data
  )
  {
    return new RegisterUserResponse
    {
      UserId = data.UserId,
      Email = data.Email,
      Disabled = data.Disabled,
    };
  }
}
