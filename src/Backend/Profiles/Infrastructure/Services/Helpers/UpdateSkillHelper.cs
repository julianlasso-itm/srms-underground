using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class UpdateSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<UpdateSkillResponse> UpdateSkillAsync(UpdateSkillRequest request)
    {
      var newUserCommand = MapToUpdateSkillCommand(request);
      var data = await Application.UpdateSkill(newUserCommand);
      return MapToUpdateSkillResponse(data);
    }

    private static UpdateSkillCommand MapToUpdateSkillCommand(UpdateSkillRequest request)
    {
      return new UpdateSkillCommand
      {
        SkillId = request.SkillId!,
        Name = request.Name,
        Disabled = request.Disable
      };
    }

    private static UpdateSkillResponse MapToUpdateSkillResponse(UpdateSkillApplicationResponse data)
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
