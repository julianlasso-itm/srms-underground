using Analytics.Application;
using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.helpers
{
    internal static class RegisterLevelHelper
    {
        private static Application<Level> s_application;

        public static void SetApplication(Application<Level> application)
        {
            s_application = application;
        }

        public static async Task<RegisterLevelResponse> RegisterLevelAsync(RegisterLevelRequest request)
        {
            var newUserCommand = MapToNewUserCommand(request);
            var data = await s_application.RegisterLevel(newUserCommand);
            return MapToRegisterLevelResponse(data);
        }

        private static RegisterLevelCommand MapToNewUserCommand(RegisterLevelRequest request)
        {
            return new RegisterLevelCommand
            {
                Name = request.Name,

            };
        }

        private static RegisterLevelResponse MapToRegisterLevelResponse(
            RegisterLevelApplicationResponse data
        )
        {
            return new RegisterLevelResponse
            {
                LevelId = data.LevelId,
                Name = data.Name,
                Disabled = data.Disabled
            };
        }
    }
}
