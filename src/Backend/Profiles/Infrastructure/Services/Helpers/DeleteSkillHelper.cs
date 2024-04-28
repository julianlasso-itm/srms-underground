using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
    public class DeleteSkillHelper : BaseHelperServiceInfrastructure
    {
        public static async Task<DeleteSkillResponse> DeleteSkillAsync(DeleteSkillRequest request)
        {
            var newUserCommand = MapToDeleteSkillCommand(request);
            var data = await Application.DeleteSkill(newUserCommand);
            return MapToDeleteSkillResponse(data);
        }

        private static DeleteSkillCommand MapToDeleteSkillCommand(DeleteSkillRequest request)
        {
            return new DeleteSkillCommand { SkillId = request.SkillId, };
        }

        private static DeleteSkillResponse MapToDeleteSkillResponse(
            DeleteSkillApplicationResponse data
        )
        {
            return new DeleteSkillResponse { SkillId = data.SkillId, };
        }
    }
}
