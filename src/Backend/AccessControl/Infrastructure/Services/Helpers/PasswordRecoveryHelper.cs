using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class PasswordRecoveryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<PasswordRecoveryAccessControlResponse>> PasswordRecoveryAsync(
      PasswordRecoveryAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToPasswordRecoveryCommand(request);
      var data = await Application.PasswordRecovery(command);

      if (data.IsFailure)
      {
        return Response<PasswordRecoveryAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<PasswordRecoveryAccessControlResponse>.Success(
        AclOutputMapper.ToPasswordRecoveryResponse(data.Data)
      );
    }
  }
}
