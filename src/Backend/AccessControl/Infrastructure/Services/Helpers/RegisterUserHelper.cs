using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class RegisterUserHelper : BaseHelperServiceInfrastructure
{
  public static async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request)
  {
    var command = AclInputMapper.ToRegisterUserCommand(request);
    var data = await Application.RegisterUser(command);
    return AclOutputMapper.ToRegisterUserResponse(data);
  }
}
