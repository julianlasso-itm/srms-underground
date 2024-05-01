using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class UpdateSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<UpdateSkillProfilesResponse> UpdateSkillAsync(
      UpdateSkillProfilesRequest request
    )
    {
      var newUserCommand = MapToUpdateSkillCommand(request);
      var data = await Application.UpdateSkill(newUserCommand);
      return MapToUpdateSkillResponse(data);
    }

    private static UpdateSkillCommand MapToUpdateSkillCommand(UpdateSkillProfilesRequest request)
    {
      return new UpdateSkillCommand
      {
        SkillId = request.SkillId!,
        Name = request.Name,
        Disabled = request.Disable
      };
    }

    private static UpdateSkillProfilesResponse MapToUpdateSkillResponse(
      UpdateSkillApplicationResponse data
    )
    {
      return new UpdateSkillProfilesResponse
      {
        SkillId = data.SkillId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
