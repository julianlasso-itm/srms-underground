using Level.Application.Commands;
using Level.Application.Responses;
using Level.Application;
using Level.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Level.Requests;
using Shared.Infrastructure.ProtocolBuffers.Level.Responses;

namespace Level.Infrastructure.Services.helpers
{
    public class GetLevelsHelper
    {
        private static Application<Level> s_application;

        public static void SetApplication(Application<Level> application)
        {
            s_application = application;
        }

        public static async Task<GetLevelsResponse> GetLevelsAsync(GetLevelsRequest request)
        {
            var newUserCommand = MapToGetLevelsCommand(request);
            var data = await s_application.GetLevels(newUserCommand);
            return MapToGetLevelsResponse(data);
        }

        private static GetLevelsCommand MapToGetLevelsCommand(GetLevelsRequest request)
        {
            return new GetLevelsCommand
            {
                Page = request.Page,
                Limit = request.Limit,
                Filter = request.Filter,
                Sort = request.Sort,
                Order = request.Order
            };
        }

        private static GetLevelsResponse MapToGetLevelsResponse(
            GetLevelsApplicationResponse<Level> data
        )
        {
            return new GetLevelsResponse
            {
                Levels = data
                .Levels.Select(skill => new LevelContract
                {
                    LevelId = skill.LevelId.ToString(),
                    Name = skill.Name,
                    Disabled = skill.Disabled
                })
                .ToList(),
                Total = data.Total
            };
        }

    }
}
