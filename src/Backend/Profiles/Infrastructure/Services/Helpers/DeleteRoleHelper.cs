using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class DeleteRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteRoleProfilesResponse> DeleteRoleAsync(
      DeleteRoleProfilesRequest request
    )
    {
      var newUserCommand = MapToDeleteRoleCommand(request);
      var data = await Application.DeleteRole(newUserCommand);
      return MapToDeleteRoleResponse(data);
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
