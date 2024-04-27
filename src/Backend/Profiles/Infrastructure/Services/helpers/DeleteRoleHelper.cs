using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class DeleteRoleHelper
    {
        private static Application<Country, State, City, Skill, Professional, Role> s_application;

        public static void SetApplication(Application<Country, State, City, Skill, Professional, Role> application)
        {
            s_application = application;
        }

        public static async Task<DeleteRoleResponse> DeleteRoleAsync(DeleteRoleRequest request)
        {
            var newUserCommand = MapToDeleteRoleCommand(request);
            var data = await s_application.DeleteRole(newUserCommand);
            return MapToDeleteRoleResponse(data);
        }

        private static DeleteRoleCommand MapToDeleteRoleCommand(DeleteRoleRequest request)
        {
            return new DeleteRoleCommand
            {
                RoleId = request.RoleId,
            };
        }

        private static DeleteRoleResponse MapToDeleteRoleResponse(
            DeleteRoleApplicationResponse data
        )
        {
            return new DeleteRoleResponse
            {
                RoleId = data.RoleId,
            };
        }
    }
}
