using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Services.Helpers;
using Infrastructure.ProtocolBuffers.AccessControl.Responses;
using ProtoBuf.Grpc;
using Shared.Application.Interfaces;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services
{
  public class AccessControlService : IAccessControlServices
  {
    private readonly ApplicationService _applicationService;
    private readonly IAntiCorruptionLayer _antiCorruptionLayerService;
    private readonly IEnvironment _environmentService;

    public AccessControlService(
      ApplicationService applicationService,
      IAntiCorruptionLayer antiCorruptionLayer,
      IEnvironment environmentService
    )
    {
      _applicationService = applicationService;
      _antiCorruptionLayerService = antiCorruptionLayer;
      _environmentService = environmentService;
    }

    public async Task<RegisterUserResponse> RegisterUserAsync(
      RegisterUserRequest request,
      CallContext context = default
    )
    {
      RegisterUserHelper.SetApplication(_applicationService.GetApplication());
      RegisterUserHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await RegisterUserHelper.RegisterUserAsync(request);
    }

    public async Task<RegisterRoleAccessControlResponse> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
      RegisterRoleHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public async Task<UpdateRoleAccessControlResponse> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
      UpdateRoleHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<DeleteRoleAccessControlResponse> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
      DeleteRoleHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public async Task<GetRolesAccessControlResponse> GetRolesAsync(
      GetRolesAccessControlRequest request,
      CallContext context = default
    )
    {
      GetRolesHelper.SetApplication(_applicationService.GetApplication());
      GetRolesHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await GetRolesHelper.GetRolesAsync(request);
    }

    public Task<ActivationTokenAccessControlResponse> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      ActiveTokenHelper.SetApplication(_applicationService.GetApplication());
      ActiveTokenHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return ActiveTokenHelper.ActivateTokenAsync(request);
    }

    public Task<SignInAccessControlResponse> SignInAsync(
      SignInAccessControlRequest request,
      CallContext context = default
    )
    {
      SignInHelper.SetApplication(_applicationService.GetApplication());
      SignInHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      SignInHelper.SetEnvironments(_environmentService);
      return SignInHelper.SignInAsync(request);
    }

    public Task<VerifyTokenAccessControlResponse> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      VerifyTokenHelper.SetApplication(_applicationService.GetApplication());
      VerifyTokenHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      VerifyTokenHelper.SetEnvironments(_environmentService);
      return VerifyTokenHelper.VerifyTokenAsync(request);
    }

    public Task<ChangePasswordAccessControlResponse> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request,
      CallContext context = default
    )
    {
      ChangePasswordHelper.SetApplication(_applicationService.GetApplication());
      ChangePasswordHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return ChangePasswordHelper.ChangePasswordAsync(request);
    }

    public Task<PasswordRecoveryAccessControlResponse> PasswordRecoveryAsync(
      PasswordRecoveryAccessControlRequest request,
      CallContext context = default
    )
    {
      PasswordRecoveryHelper.SetApplication(_applicationService.GetApplication());
      PasswordRecoveryHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return PasswordRecoveryHelper.PasswordRecoveryAsync(request);
    }

    public Task<UpdateUserAccessControlResponse> UpdateUserAsync(
      UpdateUserAccessControlRequest request,
      CallContext context = default
    )
    {
      UpdateUserHelper.SetApplication(_applicationService.GetApplication());
      UpdateUserHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return UpdateUserHelper.UpdateUserAsync(request);
    }

    public Task<ResetPasswordAccessControlResponse> ResetPasswordAsync(
      ResetPasswordAccessControlRequest request,
      CallContext context = default
    )
    {
      ResetPasswordHelper.SetApplication(_applicationService.GetApplication());
      ResetPasswordHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return ResetPasswordHelper.ResetPasswordAsync(request);
    }
  }
}
