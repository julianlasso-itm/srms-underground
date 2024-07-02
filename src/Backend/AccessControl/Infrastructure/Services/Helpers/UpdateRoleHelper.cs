using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class UpdateRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateRoleAccessControlResponse>> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToUpdateRoleCommand(request);
      var data = await Application.UpdateRole(command);

      if (data.IsFailure)
      {
        return Response<UpdateRoleAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<UpdateRoleAccessControlResponse>.Success(
        AclOutputMapper.ToUpdateRoleResponse(data.Data)
      );
    }
  }
}
