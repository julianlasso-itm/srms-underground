using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class UpdateRoleHelper : BaseHelperServiceInfrastructure
{
    public static async Task<UpdateRoleSecurityResponse> UpdateRoleAsync(
        UpdateRoleSecurityRequest request
    )
    {
        var updateRoleCommand = MapToUpdateRoleCommand(request);
        var data = await Application.UpdateRole(updateRoleCommand);
        return MapToUpdateRoleResponse(data);
    }

    private static UpdateRoleCommand MapToUpdateRoleCommand(UpdateRoleSecurityRequest request)
    {
        return new UpdateRoleCommand
        {
            RoleId = request.RoleId!,
            Name = request.Name,
            Description = request.Description,
            Disable = request.Disable
        };
    }

    private static UpdateRoleSecurityResponse MapToUpdateRoleResponse(
        UpdateRoleApplicationResponse data
    )
    {
        return new UpdateRoleSecurityResponse
        {
            RoleId = data.RoleId,
            Name = data.Name,
            Description = data.Description,
            Disabled = data.Disabled,
        };
    }
}
