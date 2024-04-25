using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

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

    private static UpdateRoleResponse MapToUpdateRoleResponse(
        UpdateRoleApplicationResponse data
    )
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
