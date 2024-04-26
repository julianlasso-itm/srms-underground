using Profiles.Application;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    internal static class UpdateSkillHelper
    {

        private static Application<Country, State, City, Skill> s_application;

        public static void SetApplication(Application<Country, State, City, Skill> application)
        {
            s_application = application;
        }

        public static async Task<UpdateSkillResponse> UpdateSkillAsync(UpdateSkillRequest request)
        {
            var newUserCommand = MapToUpdateSkillCommand(request);
            var data = await s_application.UpdateSkill(newUserCommand);
            return MapToUpdateSkillResponse(data);
        }

        private static UpdateSkillCommand MapToUpdateSkillCommand(UpdateSkillRequest request)
        {
            return new UpdateSkillCommand
            {
                SkillId = request.SkillId!,
                Name = request.Name,
                Disabled = request.Disabled
            };
        }

        private static UpdateSkillResponse MapToUpdateSkillResponse(
            UpdateSkillApplicationResponse data
        )
        {
            return new UpdateSkillResponse
            {
                SkillId = data.SkillId,
                Name = data.Name,
                Disabled = data.Disabled,
            };
        }

    }
}
