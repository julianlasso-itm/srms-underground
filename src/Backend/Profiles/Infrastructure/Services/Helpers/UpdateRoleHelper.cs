using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class UpdateRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<UpdateRoleResponse> UpdateRoleAsync(UpdateRoleRequest request)
    {
      var updateRoleCommand = MapToUpdateRoleCommand(request);
      var data = await Application.UpdateRole(updateRoleCommand);
      return MapToUpdateRoleResponse(data);
    }

    private static UpdateRoleCommand MapToUpdateRoleCommand(UpdateRoleRequest request)
    {
      return new UpdateRoleCommand
      {
        RoleId = request.RoleId!,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable
      };
    }

    private static UpdateRoleResponse MapToUpdateRoleResponse(UpdateRoleApplicationResponse data)
    {
      return new UpdateRoleResponse
      {
        RoleId = data.RoleId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
      };
    }
  }
}
