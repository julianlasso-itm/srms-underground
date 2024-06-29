using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using Shared.Infrastructure.ProtocolBuffers;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class RegisterUserHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<GrpcResult<RegisterUserResponse>> RegisterUserAsync(
      RegisterUserRequest request
    )
    {
      var command = AclInputMapper.ToRegisterUserCommand(request);
      var data = await Application.RegisterUser(command);

      if (data.IsFailure)
      {
        return GrpcResult<RegisterUserResponse>.Failure(
          data.Message ?? string.Empty,
          data.Code ?? ErrorEnum.INTERNAL_SERVER_ERROR,
          data.Details
        );
      }

      var answer = GrpcResult<RegisterUserResponse>.Success(
        AclOutputMapper.ToRegisterUserResponse(data.Data)
      );
      return answer;
    }
  }
}
