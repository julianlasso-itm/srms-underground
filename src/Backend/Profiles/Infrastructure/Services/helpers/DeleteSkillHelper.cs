using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class DeleteSkillHelper
    {
        private static Application<Country, State, City, Skill> s_application;

        public static void SetApplication(Application<Country, State, City, Skill> application)
        {
            s_application = application;
        }

        public static async Task<DeleteSkillResponse> DeleteSkillAsync(DeleteSkillRequest request)
        {
            var newUserCommand = MapToDeleteSkillCommand(request);
            var data = await s_application.DeleteSkill(newUserCommand);
            return MapToDeleteSkillResponse(data);
        }

        private static DeleteSkillCommand MapToDeleteSkillCommand(DeleteSkillRequest request)
        {
            return new DeleteSkillCommand
            {
                SkillId = request.SkillId,
            };
        }

        private static DeleteSkillResponse MapToDeleteSkillResponse(
            DeleteSkillApplicationResponse data
        )
        {
            return new DeleteSkillResponse
            {
                SkillId = data.SkillId,
            };
        }
    }
}
