using AccessControl.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services;

public class AccessControlService : IAccessControlServices
{
    private readonly ApplicationService _applicationService;

    public AccessControlService(ApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    public async Task<RegisterRoleResponse> RegisterRoleAsync(
        RegisterRoleRequest request,
        CallContext context = default
    )
    {
        RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
        return await RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public async Task<UpdateRoleResponse> UpdateRoleAsync(
        UpdateRoleRequest request,
        CallContext context = default
    )
    {
        UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
        return await UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<DeleteRoleResponse> DeleteRoleAsync(
        DeleteRoleRequest request,
        CallContext context = default
    )
    {
        DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
        return await DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public async Task<GetRolesResponse> GetRolesAsync(
        GetRolesRequest request,
        CallContext context = default
    )
    {
        GetRolesHelper.SetApplication(_applicationService.GetApplication());
        return await GetRolesHelper.GetRolesAsync(request);
    }
}
