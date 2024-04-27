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

    public async Task<RegisterRoleSecurityResponse> RegisterRoleAsync(
        RegisterRoleSecurityRequest request,
        CallContext context = default
    )
    {
        RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
        return await RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public async Task<UpdateRoleSecurityResponse> UpdateRoleAsync(
        UpdateRoleSecurityRequest request,
        CallContext context = default
    )
    {
        UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
        return await UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<DeleteRoleSecurityResponse> DeleteRoleAsync(
        DeleteRoleSecurityRequest request,
        CallContext context = default
    )
    {
        DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
        return await DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public async Task<GetRolesSecurityResponse> GetRolesAsync(
        GetRolesSecurityRequest request,
        CallContext context = default
    )
    {
        GetRolesHelper.SetApplication(_applicationService.GetApplication());
        return await GetRolesHelper.GetRolesAsync(request);
    }
}
