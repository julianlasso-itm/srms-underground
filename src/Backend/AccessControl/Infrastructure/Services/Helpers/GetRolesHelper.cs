using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class GetRolesHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<GetRolesAccessControlResponse>> GetRolesAsync(
      GetRolesAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToGetRolesCommand(request);
      var data = await Application.GetRoles(command);

      if (data.IsFailure)
      {
        return Response<GetRolesAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<GetRolesAccessControlResponse>.Success(
        AclOutputMapper.ToGetRolesResponse(data.Data)
      );
    }
  }
}
