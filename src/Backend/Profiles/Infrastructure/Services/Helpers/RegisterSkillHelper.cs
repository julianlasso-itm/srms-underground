using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class RegisterSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterSkillProfilesResponse>> RegisterSkillAsync(
      RegisterSkillProfilesRequest request
    )
    {
      var newUserCommand = MapToNewUserCommand(request);
      var response = await Application.RegisterSkill(newUserCommand);

      if (response.IsFailure)
      {
        return Response<RegisterSkillProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<RegisterSkillProfilesResponse>.Success(
        MapToRegisterSkillResponse(response.Data)
      );
    }

    private static RegisterSkillCommand MapToNewUserCommand(RegisterSkillProfilesRequest request)
    {
      return new RegisterSkillCommand { Name = request.Name, };
    }

    private static RegisterSkillProfilesResponse MapToRegisterSkillResponse(
      RegisterSkillApplicationResponse data
    )
    {
      return new RegisterSkillProfilesResponse
      {
        SkillId = data.SkillId,
        Name = data.Name,
        Disabled = data.Disabled
      };
    }
  }
}
