using Profiles.Application;
using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    internal static class RegisterSkillHelper
    {
        private static Application<Country, State, City, Skill> s_application;

        public static void SetApplication(Application<Country, State, City, Skill> application)
        {
            s_application = application;
        }

        public static async Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request)
        {
            var newUserCommand = MapToNewUserCommand(request);
            var data = await s_application.RegisterSkill(newUserCommand);
            return MapToRegisterSkillResponse(data);
        }

        private static RegisterSkillCommand MapToNewUserCommand(RegisterSkillRequest request)
        {
            return new RegisterSkillCommand
            {
                Name = request.Name,

            };
        }

        private static RegisterSkillResponse MapToRegisterSkillResponse(
            RegisterSkillApplicationResponse data
        )
        {
            return new RegisterSkillResponse
            {
                SkillId = data.SkillId,
                Name = data.Name,
                Disabled = data.Disabled
            };
        }
    }
}
