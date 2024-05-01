using Analytics.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Analytics;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services
{
  public class AnalyticsService : IAnalyticsServices
  {
    private readonly ApplicationService _applicationService;

    public AnalyticsService(ApplicationService applicationService)
    {
      _applicationService = applicationService;
    }

    public async Task<RegisterLevelAnalyticsResponse> RegisterLevelAsync(
      RegisterLevelAnalyticsRequest request,
      CallContext context = default
    )
    {
      RegisterLevelHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterLevelHelper.RegisterLevelAsync(request);
    }

    public async Task<UpdateLevelAnalyticsResponse> UpdateLevelAsync(
      UpdateLevelAnalyticsRequest request,
      CallContext context = default
    )
    {
      UpdateLevelHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateLevelHelper.UpdateLevelAsync(request);
    }

    public async Task<DeleteLevelAnalyticsResponse> DeleteLevelAsync(
      DeleteLevelAnalyticsRequest request,
      CallContext context = default
    )
    {
      DeleteLevelHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteLevelHelper.DeleteLevelAsync(request);
    }

    public async Task<GetLevelsAnalyticsResponse> GetLevelsAsync(
      GetLevelsAnalyticsRequest request,
      CallContext context = default
    )
    {
      GetLevelsHelper.SetApplication(_applicationService.GetApplication());
      return await GetLevelsHelper.GetLevelsAsync(request);
    }
  }
}
