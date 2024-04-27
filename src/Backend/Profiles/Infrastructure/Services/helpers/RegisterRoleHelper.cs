using Profiles.Application;
using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    internal static class RegisterRoleHelper
    {
        private static Application<Country, State, City, Skill, Professional, Role> s_application;

        public static void SetApplication(Application<Country, State, City, Skill, Professional, Role> application)
        {
            s_application = application;
        }

        public static async Task<RegisterRoleResponse> RegisterRoleAsync(RegisterRoleRequest request)
        {
            var newUserCommand = MapToNewUserCommand(request);
            var data = await s_application.RegisterRole(newUserCommand);
            return MapToRegisterRoleResponse(data);
        }

        private static RegisterRoleCommand MapToNewUserCommand(RegisterRoleRequest request)
        {
            return new RegisterRoleCommand
            {
                Name = request.Name,

            };
        }

        private static RegisterRoleResponse MapToRegisterRoleResponse(
            RegisterRoleApplicationResponse data
        )
        {
            return new RegisterRoleResponse
            {
                RoleId = data.RoleId,
                Name = data.Name,
                Description = data.Description,
                Disabled = data.Disabled
            };
        }
    }
}
