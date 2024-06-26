using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class GetSkillsHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<GetSkillsProfilesResponse>> GetSkillsAsync(
      GetSkillsProfilesRequest request
    )
    {
      var newUserCommand = MapToGetSkillsCommand(request);
      var response = await Application.GetSkills(newUserCommand);

      if (response.IsFailure)
      {
        return Response<GetSkillsProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<GetSkillsProfilesResponse>.Success(MapToGetSkillsResponse(response.Data));
    }

    private static GetSkillsCommand MapToGetSkillsCommand(GetSkillsProfilesRequest request)
    {
      return new GetSkillsCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    private static GetSkillsProfilesResponse MapToGetSkillsResponse(
      GetSkillsApplicationResponse<SkillModel> data
    )
    {
      return new GetSkillsProfilesResponse
      {
        Skills = data
          .Skills.Select(skill => new SkillProfiles
          {
            SkillId = skill.SkillId.ToString(),
            Name = skill.Name,
            Disabled = skill.Disabled
          })
          .ToList(),
        Total = data.Total
      };
    }
  }
}
