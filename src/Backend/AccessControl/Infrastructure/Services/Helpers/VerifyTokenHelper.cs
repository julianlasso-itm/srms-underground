using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class VerifyTokenHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<VerifyTokenAccessControlResponse>> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request
    )
    {
      request.PublicKeyPath = Configuration.GetVariable("PUBLIC_KEY_PATH");
      request.PrivateKeyPath = Configuration.GetVariable("PRIVATE_KEY_PATH");
      var command = AclInputMapper.ToVerifyTokenCommand(request);
      var data = await Application.VerifyToken(command);

      if (data.IsFailure)
      {
        return Response<VerifyTokenAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<VerifyTokenAccessControlResponse>.Success(
        AclOutputMapper.ToVerifyTokenResponse(data.Data)
      );
    }
  }
}
