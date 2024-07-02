using AccessControl.Infrastructure.Services.Helpers.Base;
using Infrastructure.ProtocolBuffers.AccessControl.Responses;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class ResetPasswordHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<ResetPasswordAccessControlResponse>> ResetPasswordAsync(
      ResetPasswordAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToResetPasswordCommand(request);
      var data = await Application.ResetPassword(command);

      if (data.IsFailure)
      {
        return Response<ResetPasswordAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<ResetPasswordAccessControlResponse>.Success(
        AclOutputMapper.ToResetPasswordResponse(data.Data)
      );
    }
  }
}
