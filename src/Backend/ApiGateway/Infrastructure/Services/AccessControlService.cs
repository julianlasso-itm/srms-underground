using System.Text.Json;
using ApiGateway.Infrastructure.Services.Base;
using Infrastructure.ProtocolBuffers.AccessControl.Responses;
using ProtoBuf.Grpc;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using Shared.Infrastructure.ProtocolBuffers;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace ApiGateway.Infrastructure.Services
{
  public class AccessControlService : BaseServices<IAccessControlServices>, IAccessControlServices
  {
    public AccessControlService(string urlMicroservice, HttpClientHandler? httpClientHandler = null)
      : base(httpClientHandler)
    {
      CreateChannel(urlMicroservice);
    }

    public async Task<GrpcResult<RegisterUserResponse>> RegisterUserAsync(
      RegisterUserRequest request,
      CallContext context = default
    )
    {
      try
      {
        var response = await Client.RegisterUserAsync(request, context);
        Console.WriteLine($"Response: {JsonSerializer.Serialize(response)}");
        return response;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Exception: {ex.Message}");

        var message = ex.Message ?? string.Empty;
        if (ex.StackTrace != null)
        {
          message += JsonSerializer.Serialize(ex.StackTrace);
        }

        return GrpcResult<RegisterUserResponse>.Failure(message, ErrorEnum.INTERNAL_SERVER_ERROR);
        // return Response<RegisterUserResponse>.Failure(message, ErrorEnum.INTERNAL_SERVER_ERROR);
      }
    }

    public Task<Result<RegisterRoleAccessControlResponse>> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterRoleAsync(request, context);
    }

    public Task<Result<UpdateRoleAccessControlResponse>> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateRoleAsync(request, context);
    }

    public Task<Result<DeleteRoleAccessControlResponse>> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteRoleAsync(request, context);
    }

    public Task<Result<GetRolesAccessControlResponse>> GetRolesAsync(
      GetRolesAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.GetRolesAsync(request, context);
    }

    public Task<Result<ActivationTokenAccessControlResponse>> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.ActivateTokenAsync(request, context);
    }

    public Task<Result<SignInAccessControlResponse>> SignInAsync(
      SignInAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.SignInAsync(request, context);
    }

    public Task<Result<VerifyTokenAccessControlResponse>> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.VerifyTokenAsync(request, context);
    }

    public Task<Result<ChangePasswordAccessControlResponse>> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.ChangePasswordAsync(request, context);
    }

    public Task<Result<PasswordRecoveryAccessControlResponse>> PasswordRecoveryAsync(
      PasswordRecoveryAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.PasswordRecoveryAsync(request, context);
    }

    public Task<Result<UpdateUserAccessControlResponse>> UpdateUserAsync(
      UpdateUserAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateUserAsync(request, context);
    }

    public Task<Result<ResetPasswordAccessControlResponse>> ResetPasswordAsync(
      ResetPasswordAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.ResetPasswordAsync(request, context);
    }
  }
}
