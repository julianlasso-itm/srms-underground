using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
    public class RegisterSkillHelper : BaseHelperServiceInfrastructure
    {
        public static async Task<RegisterSkillResponse> RegisterSkillAsync(
            RegisterSkillRequest request
        )
        {
            var newUserCommand = MapToNewUserCommand(request);
            var data = await Application.RegisterSkill(newUserCommand);
            return MapToRegisterSkillResponse(data);
        }

        private static RegisterSkillCommand MapToNewUserCommand(RegisterSkillRequest request)
        {
            return new RegisterSkillCommand { Name = request.Name, };
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
