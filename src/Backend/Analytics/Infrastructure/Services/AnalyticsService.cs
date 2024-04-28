using Analytics.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Analytics;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services;

public class AnalyticsService : IAnalyticsServices
{
    private readonly ApplicationService _applicationService;

    public AnalyticsService(ApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    public async Task<RegisterLevelSecurityResponse> RegisterLevelAsync(
        RegisterLevelSecurityRequest request,
        CallContext context = default
    )
    {
        RegisterLevelHelper.SetApplication(_applicationService.GetApplication());
        return await RegisterLevelHelper.RegisterLevelAsync(request);
    }

    public async Task<UpdateLevelSecurityResponse> UpdateLevelAsync(
        UpdateLevelSecurityRequest request,
        CallContext context = default
    )
    {
        UpdateLevelHelper.SetApplication(_applicationService.GetApplication());
        return await UpdateLevelHelper.UpdateLevelAsync(request);
    }

    public async Task<DeleteLevelSecurityResponse> DeleteLevelAsync(
        DeleteLevelSecurityRequest request,
        CallContext context = default
    )
    {
        DeleteLevelHelper.SetApplication(_applicationService.GetApplication());
        return await DeleteLevelHelper.DeleteLevelAsync(request);
    }

    public async Task<GetLevelsSecurityResponse> GetLevelsAsync(
        GetLevelsSecurityRequest request,
        CallContext context = default
    )
    {
        GetLevelsHelper.SetApplication(_applicationService.GetApplication());
        return await GetLevelsHelper.GetLevelsAsync(request);
    }
}
