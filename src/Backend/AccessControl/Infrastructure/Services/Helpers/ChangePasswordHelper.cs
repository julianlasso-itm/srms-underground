using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class ChangePasswordHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<ChangePasswordAccessControlResponse>> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToChangePasswordCommand(request);
      var data = await Application.ChangePassword(command);

      if (data.IsFailure)
      {
        return Response<ChangePasswordAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<ChangePasswordAccessControlResponse>.Success(
        AclOutputMapper.ToChangePasswordResponse(data.Data)
      );
    }
  }
}
