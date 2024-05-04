using AccessControl.AntiCorruption.Interfaces;
using AccessControl.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services
{
  public class AccessControlService : IAccessControlServices
  {
    private readonly ApplicationService _applicationService;
    private readonly IAntiCorruptionLayer _antiCorruptionLayerService;

    public AccessControlService(
      ApplicationService applicationService,
      IAntiCorruptionLayer antiCorruptionLayer
    )
    {
      _applicationService = applicationService;
      _antiCorruptionLayerService = antiCorruptionLayer;
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
  }
}
