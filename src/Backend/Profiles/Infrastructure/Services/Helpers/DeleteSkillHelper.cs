using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class DeleteSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<DeleteSkillProfilesResponse>> DeleteSkillAsync(
      DeleteSkillProfilesRequest request
    )
    {
      var newUserCommand = MapToDeleteSkillCommand(request);
      var response = await Application.DeleteSkill(newUserCommand);

      if (response.IsFailure)
      {
        return Response<DeleteSkillProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteSkillProfilesResponse>.Success(MapToDeleteSkillResponse(response.Data));
    }

    private static DeleteSkillCommand MapToDeleteSkillCommand(DeleteSkillProfilesRequest request)
    {
      return new DeleteSkillCommand { SkillId = request.SkillId, };
    }

    private static DeleteSkillProfilesResponse MapToDeleteSkillResponse(
      DeleteSkillApplicationResponse data
    )
    {
      return new DeleteSkillProfilesResponse { SkillId = data.SkillId, };
    }
  }
}
