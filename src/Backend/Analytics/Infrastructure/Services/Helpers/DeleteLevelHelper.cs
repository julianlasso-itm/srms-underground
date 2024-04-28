using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Application;
using Analytics.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.helpers
{
    public class DeleteLevelHelper
    {
        private static Application<Level> s_application;

        public static void SetApplication(Application<Level> application)
        {
            s_application = application;
        }

        public static async Task<DeleteLevelResponse> DeleteLevelAsync(DeleteLevelRequest request)
        {
            var newUserCommand = MapToDeleteLevelCommand(request);
            var data = await s_application.DeleteLevel(newUserCommand);
            return MapToDeleteLevelResponse(data);
        }

        private static DeleteLevelCommand MapToDeleteLevelCommand(DeleteLevelRequest request)
        {
            return new DeleteLevelCommand
            {
                LevelId = request.LevelId,
            };
        }

        private static DeleteLevelResponse MapToDeleteLevelResponse(
            DeleteLevelApplicationResponse data
        )
        {
            return new DeleteLevelResponse
            {
                LevelId = data.LevelId,
            };
        }
    }
}
