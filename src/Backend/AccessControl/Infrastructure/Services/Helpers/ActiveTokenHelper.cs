using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class ActiveTokenHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<ActivationTokenAccessControlResponse>> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToActivateTokenCommand(request);
      var data = await Application.ActivateToken(command);

      if (data.IsFailure)
      {
        return Response<ActivationTokenAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<ActivationTokenAccessControlResponse>.Success(
        AclOutputMapper.ToActivateTokenResponse(data.Data)
      );
    }
  }
}
