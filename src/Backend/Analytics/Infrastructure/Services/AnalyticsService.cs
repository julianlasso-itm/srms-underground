
using Analytics.Infrastructure.Services.helpers;
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

        public async Task<DeleteLevelResponse> DeleteLevelAsync(DeleteLevelRequest request, CallContext context = default)
        {
            DeleteLevelHelper.SetApplication(_applicationService.GetApplication());
            return await DeleteLevelHelper.DeleteLevelAsync(request);
        }

        public async Task<GetLevelResponse> GetLevelAsync(GetLevelsRequest request, CallContext context = default)
        {
            GetLevelHelper.SetApplication(_applicationService.GetApplication());
            return await GetLevelHelper.GetLevelsAsync(request);
        }

        public async Task<RegisterLevelResponse> RegisterLevelAsync(RegisterLevelRequest request, CallContext context = default)
        {
            RegisterLevelHelper.SetApplication(_applicationService.GetApplication());
            return await RegisterLevelHelper.RegisterLevelAsync(request);
        }

        public async Task<UpdateLevelResponse> UpdateLevelAsync(UpdateLevelRequest request, CallContext context = default)
        {
            UpdateLevelHelper.SetApplication(_applicationService.GetApplication());
            return await UpdateLevelHelper.UpdateLevelAsync(request);
        }
    }
}
