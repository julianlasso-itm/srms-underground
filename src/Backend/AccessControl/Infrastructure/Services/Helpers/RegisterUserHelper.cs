using System.Text.Json;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class RegisterUserHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<ResultRegisterUser> RegisterUserAsync(RegisterUserRequest request)
    {
      var command = AclInputMapper.ToRegisterUserCommand(request);
      var data = await Application.RegisterUser(command);

      if (data.IsFailure)
      {
        return new ResultRegisterUser
        {
          Success = false,
          ErrorCode = data.Code.ToString(),
          ErrorDetails =
            data.Details != null ? JsonSerializer.Serialize(data.Details) : string.Empty,
          ErrorMessage = data.Message,
        };
      }

      // var answer = Response<RegisterUserResponse>.Success(
      //   AclOutputMapper.ToRegisterUserResponse(data.Data)
      // );
      var answer = new ResultRegisterUser
      {
        Data = AclOutputMapper.ToRegisterUserResponse(data.Data),
      };
      return answer;
    }
  }
}
