using ApiGateway.Infrastructure.Services.Base;
using Infrastructure.ProtocolBuffers.AccessControl.Responses;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace ApiGateway.Infrastructure.Services
{
  public class AccessControlService : BaseServices<IAccessControlServices>, IAccessControlServices
  {
    const string UrlMicroservice = "http://localhost:5297";

    public AccessControlService(HttpClientHandler? httpClientHandler = null)
      : base(httpClientHandler)
    {
      CreateChannel(UrlMicroservice);
    }

    public Task<RegisterUserResponse> RegisterUserAsync(
      RegisterUserRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterUserAsync(request, context);
    }

    public Task<RegisterRoleAccessControlResponse> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterRoleAsync(request, context);
    }

    public Task<UpdateRoleAccessControlResponse> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateRoleAsync(request, context);
    }

    public Task<DeleteRoleAccessControlResponse> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteRoleAsync(request, context);
    }

    public Task<GetRolesAccessControlResponse> GetRolesAsync(
      GetRolesAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.GetRolesAsync(request, context);
    }

    public Task<ActivationTokenAccessControlResponse> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.ActivateTokenAsync(request, context);
    }

    public Task<SignInAccessControlResponse> SignInAsync(
      SignInAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.SignInAsync(request, context);
    }

    public Task<VerifyTokenAccessControlResponse> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.VerifyTokenAsync(request, context);
    }

    public Task<ChangePasswordAccessControlResponse> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.ChangePasswordAsync(request, context);
    }

    public Task<PasswordRecoveryAccessControlResponse> PasswordRecoveryAsync(
      PasswordRecoveryAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.PasswordRecoveryAsync(request, context);
    }

    public Task<UpdateUserAccessControlResponse> UpdateUserAsync(
      UpdateUserAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateUserAsync(request, context);
    }

    public Task<ResetPasswordAccessControlResponse> ResetPasswordAsync(
      ResetPasswordAccessControlRequest request,
      CallContext context = default
    )
    {
      return Client.ResetPasswordAsync(request, context);
    }
  }
}
