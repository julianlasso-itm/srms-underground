using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Services.Helpers;
using Infrastructure.ProtocolBuffers.AccessControl.Responses;
using ProtoBuf.Grpc;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services
{
  public class AccessControlService(
    ApplicationService applicationService,
    IAntiCorruptionLayer antiCorruptionLayer,
    IEnvironment environmentService
  ) : IAccessControlServices
  {
    private readonly ApplicationService _applicationService = applicationService;
    private readonly IAntiCorruptionLayer _antiCorruptionLayerService = antiCorruptionLayer;
    private readonly IEnvironment _environmentService = environmentService;

    public async Task<Result<RegisterUserResponse>> RegisterUserAsync(
      RegisterUserRequest request,
      CallContext context = default
    )
    {
      RegisterUserHelper.SetApplication(_applicationService.GetApplication());
      RegisterUserHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await RegisterUserHelper.RegisterUserAsync(request);
    }

    public async Task<Result<RegisterRoleAccessControlResponse>> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
      RegisterRoleHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public async Task<Result<UpdateRoleAccessControlResponse>> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
      UpdateRoleHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<Result<DeleteRoleAccessControlResponse>> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request,
      CallContext context = default
    )
    {
      DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
      DeleteRoleHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public async Task<Result<GetRolesAccessControlResponse>> GetRolesAsync(
      GetRolesAccessControlRequest request,
      CallContext context = default
    )
    {
      GetRolesHelper.SetApplication(_applicationService.GetApplication());
      GetRolesHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return await GetRolesHelper.GetRolesAsync(request);
    }

    public Task<Result<ActivationTokenAccessControlResponse>> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      ActiveTokenHelper.SetApplication(_applicationService.GetApplication());
      ActiveTokenHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return ActiveTokenHelper.ActivateTokenAsync(request);
    }

    public Task<Result<SignInAccessControlResponse>> SignInAsync(
      SignInAccessControlRequest request,
      CallContext context = default
    )
    {
      SignInHelper.SetApplication(_applicationService.GetApplication());
      SignInHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      SignInHelper.SetEnvironments(_environmentService);
      return SignInHelper.SignInAsync(request);
    }

    public Task<Result<VerifyTokenAccessControlResponse>> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request,
      CallContext context = default
    )
    {
      VerifyTokenHelper.SetApplication(_applicationService.GetApplication());
      VerifyTokenHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      VerifyTokenHelper.SetEnvironments(_environmentService);
      return VerifyTokenHelper.VerifyTokenAsync(request);
    }

    public Task<Result<ChangePasswordAccessControlResponse>> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request,
      CallContext context = default
    )
    {
      ChangePasswordHelper.SetApplication(_applicationService.GetApplication());
      ChangePasswordHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return ChangePasswordHelper.ChangePasswordAsync(request);
    }

    public Task<Result<PasswordRecoveryAccessControlResponse>> PasswordRecoveryAsync(
      PasswordRecoveryAccessControlRequest request,
      CallContext context = default
    )
    {
      PasswordRecoveryHelper.SetApplication(_applicationService.GetApplication());
      PasswordRecoveryHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return PasswordRecoveryHelper.PasswordRecoveryAsync(request);
    }

    public Task<Result<UpdateUserAccessControlResponse>> UpdateUserAsync(
      UpdateUserAccessControlRequest request,
      CallContext context = default
    )
    {
      UpdateUserHelper.SetApplication(_applicationService.GetApplication());
      UpdateUserHelper.SetAntiCorruptionLayer(_antiCorruptionLayerService);
      return UpdateUserHelper.UpdateUserAsync(request);
    }

    public Task<Result<ResetPasswordAccessControlResponse>> ResetPasswordAsync(
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
