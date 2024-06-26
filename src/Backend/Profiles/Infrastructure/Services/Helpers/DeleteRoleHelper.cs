using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class DeleteRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<DeleteRoleProfilesResponse>> DeleteRoleAsync(
      DeleteRoleProfilesRequest request
    )
    {
      var newUserCommand = MapToDeleteRoleCommand(request);
      var response = await Application.DeleteRole(newUserCommand);

      if (response.IsFailure)
      {
        return Response<DeleteRoleProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteRoleProfilesResponse>.Success(MapToDeleteRoleResponse(response.Data));
    }

    private static DeleteRoleCommand MapToDeleteRoleCommand(DeleteRoleProfilesRequest request)
    {
      return new DeleteRoleCommand { RoleId = request.RoleId, };
    }

    private static DeleteRoleProfilesResponse MapToDeleteRoleResponse(
      DeleteRoleApplicationResponse data
    )
    {
      return new DeleteRoleProfilesResponse { RoleId = data.RoleId, };
    }
  }
}
