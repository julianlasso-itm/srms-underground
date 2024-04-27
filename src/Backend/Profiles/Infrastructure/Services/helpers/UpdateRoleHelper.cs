using Profiles.Application;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    internal static class UpdateRoleHelper
    {

        private static Application<Country, State, City, Skill, Professional, Role> s_application;

        public static void SetApplication(Application<Country, State, City, Skill, Professional, Role> application)
        {
            s_application = application;
        }

        public static async Task<UpdateRoleResponse> UpdateRoleAsync(UpdateRoleRequest request)
        {
            var newUserCommand = MapToUpdateRoleCommand(request);
            var data = await s_application.UpdateRole(newUserCommand);
            return MapToUpdateRoleResponse(data);
        }

        private static UpdateRoleCommand MapToUpdateRoleCommand(UpdateRoleRequest request)
        {
            return new UpdateRoleCommand
            {
                RoleId = request.RoleId!,
                Name = request.Name,
                Description = request.Description,
                Disabled = request.Disabled
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
}
