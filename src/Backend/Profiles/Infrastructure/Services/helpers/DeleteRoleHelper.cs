using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class DeleteRoleHelper : BaseHelperServiceInfrastructure
    {
        public static async Task<DeleteRoleResponse> DeleteRoleAsync(DeleteRoleRequest request)
        {
            var newUserCommand = MapToDeleteRoleCommand(request);
            var data = await Application.DeleteRole(newUserCommand);
            return MapToDeleteRoleResponse(data);
        }

        private static DeleteRoleCommand MapToDeleteRoleCommand(DeleteRoleRequest request)
        {
            return new DeleteRoleCommand { RoleId = request.RoleId, };
        }

        private static DeleteRoleResponse MapToDeleteRoleResponse(
            DeleteRoleApplicationResponse data
        )
        {
            return new DeleteRoleResponse { RoleId = data.RoleId, };
        }
    }
}
