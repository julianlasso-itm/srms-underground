using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class DeleteRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<DeleteRoleAccessControlResponse>> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToDeleteRoleCommand(request);
      var data = await Application.DeleteRole(command);

      if (data.IsFailure)
      {
        return Response<DeleteRoleAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<DeleteRoleAccessControlResponse>.Success(
        AclOutputMapper.ToDeleteRoleResponse(data.Data)
      );
    }
  }
}
