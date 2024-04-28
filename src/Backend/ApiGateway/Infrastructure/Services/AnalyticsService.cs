using ApiGateway.Infrastructure.Services.Base;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Analytics;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace ApiGateway.Infrastructure.Services;

public class AnalyticsService : BaseServices<IAnalyticsServices>, IAnalyticsServices
{
    const string UrlMicroservice = "http://localhost:5098";

    public AnalyticsService(HttpClientHandler? httpClientHandler = null)
        : base(httpClientHandler)
    {
        CreateChannel(UrlMicroservice);
    }

    public Task<RegisterLevelSecurityResponse> RegisterLevelAsync(
        RegisterLevelSecurityRequest request,
        CallContext context = default
    )
    {
        return Client.RegisterLevelAsync(request, context);
    }

    public Task<UpdateLevelSecurityResponse> UpdateLevelAsync(
        UpdateLevelSecurityRequest request,
        CallContext context = default
    )
    {
        return Client.UpdateLevelAsync(request, context);
    }

    public Task<DeleteLevelSecurityResponse> DeleteLevelAsync(
        DeleteLevelSecurityRequest request,
        CallContext context = default
    )
    {
        return Client.DeleteLevelAsync(request, context);
    }

    public Task<GetLevelsSecurityResponse> GetLevelsAsync(
        GetLevelsSecurityRequest request,
        CallContext context = default
    )
    {
        return Client.GetLevelsAsync(request, context);
    }
}
