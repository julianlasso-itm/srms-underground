using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class UpdateRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateRoleProfilesResponse>> UpdateRoleAsync(
      UpdateRoleProfilesRequest request
    )
    {
      var updateRoleCommand = MapToUpdateRoleCommand(request);
      var response = await Application.UpdateRole(updateRoleCommand);

      if (response.IsFailure)
      {
        return Response<UpdateRoleProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<UpdateRoleProfilesResponse>.Success(MapToUpdateRoleResponse(response.Data));
    }

    private static UpdateRoleCommand MapToUpdateRoleCommand(UpdateRoleProfilesRequest request)
    {
      return new UpdateRoleCommand
      {
        RoleId = request.RoleId!,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable,
        Skills = request.Skills,
      };
    }

    private static UpdateRoleProfilesResponse MapToUpdateRoleResponse(
      UpdateRoleApplicationResponse data
    )
    {
      return new UpdateRoleProfilesResponse
      {
        RoleId = data.RoleId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
        Skills = data.Skills,
      };
    }
  }
}
