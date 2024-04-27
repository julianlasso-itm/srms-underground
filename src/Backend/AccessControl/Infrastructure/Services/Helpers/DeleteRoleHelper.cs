using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class DeleteRoleHelper : BaseHelperServiceInfrastructure
{
    public static async Task<DeleteRoleSecurityResponse> DeleteRoleAsync(
        DeleteRoleSecurityRequest request
    )
    {
        var deleteRoleCommand = MapToDeleteRoleCommand(request);
        var data = await Application.DeleteRole(deleteRoleCommand);
        return MapToDeleteRoleResponse(data);
    }

    private static DeleteRoleCommand MapToDeleteRoleCommand(DeleteRoleSecurityRequest request)
    {
        return new DeleteRoleCommand { RoleId = request.RoleId };
    }

    private static DeleteRoleSecurityResponse MapToDeleteRoleResponse(
        DeleteRoleApplicationResponse data
    )
    {
        return new DeleteRoleSecurityResponse { RoleId = data.RoleId };
    }
}
