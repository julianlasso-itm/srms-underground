using Analytics.Application;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.helpers
{
    internal static class UpdateLevelHelper
    {

        private static Application<Level> s_application;

        public static void SetApplication(Application<Level> application)
        {
            s_application = application;
        }

        public static async Task<UpdateLevelResponse> UpdateLevelAsync(UpdateLevelRequest request)
        {
            var newUserCommand = MapToUpdateLevelCommand(request);
            var data = await s_application.UpdateLevel(newUserCommand);
            return MapToUpdateLevelResponse(data);
        }

        private static UpdateLevelCommand MapToUpdateLevelCommand(UpdateLevelRequest request)
        {
            return new UpdateLevelCommand
            {
                LevelId = request.LevelId!,
                Name = request.Name,
                Disabled = request.Disabled
            };
        }

        private static UpdateLevelResponse MapToUpdateLevelResponse(
            UpdateLevelApplicationResponse data
        )
        {
            return new UpdateLevelResponse
            {
                LevelId = data.LevelId,
                Name = data.Name,
                Disabled = data.Disabled,
            };
        }

    }
}
