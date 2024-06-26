using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class UpdateSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateSkillProfilesResponse>> UpdateSkillAsync(
      UpdateSkillProfilesRequest request
    )
    {
      var newUserCommand = MapToUpdateSkillCommand(request);
      var response = await Application.UpdateSkill(newUserCommand);

      if (response.IsFailure)
      {
        return Response<UpdateSkillProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<UpdateSkillProfilesResponse>.Success(MapToUpdateSkillResponse(response.Data));
    }

    private static UpdateSkillCommand MapToUpdateSkillCommand(UpdateSkillProfilesRequest request)
    {
      return new UpdateSkillCommand
      {
        SkillId = request.SkillId!,
        Name = request.Name,
        Disable = request.Disable
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
