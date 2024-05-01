using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class RegisterRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<RegisterRoleAccessControlResponse> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request
    )
    {
      var newRoleCommand = MapToRegisterRoleCommand(request);
      var data = await Application.RegisterRole(newRoleCommand);
      return MapToRegisterRoleResponse(data);
    }

    private static RegisterRoleCommand MapToRegisterRoleCommand(
      RegisterRoleAccessControlRequest request
    )
    {
      return new RegisterRoleCommand { Name = request.Name, Description = request.Description, };
    }

    private static RegisterRoleAccessControlResponse MapToRegisterRoleResponse(
      RegisterRoleApplicationResponse data
    )
    {
      return new RegisterRoleAccessControlResponse
      {
        RoleId = data.RoleId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
      };
    }
  }
}
