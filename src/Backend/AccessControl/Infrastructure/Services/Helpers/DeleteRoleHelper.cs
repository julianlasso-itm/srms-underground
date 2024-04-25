using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class DeleteRoleHelper : BaseHelperServiceInfrastructure
{
    public static async Task<DeleteRoleResponse> DeleteRoleAsync(DeleteRoleRequest request)
    {
        var deleteRoleCommand = MapToDeleteRoleCommand(request);
        var data = await Application.DeleteRole(deleteRoleCommand);
        return MapToDeleteRoleResponse(data);
    }

    private static DeleteRoleCommand MapToDeleteRoleCommand(DeleteRoleRequest request)
    {
        return new DeleteRoleCommand { RoleId = request.RoleId };
    }

    private static DeleteRoleResponse MapToDeleteRoleResponse(DeleteRoleApplicationResponse data)
    {
        return new DeleteRoleResponse { RoleId = data.RoleId };
    }
}
