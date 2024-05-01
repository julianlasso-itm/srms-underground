using ApiGateway.Infrastructure.Services.Base;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Analytics;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace ApiGateway.Infrastructure.Services
{
  public class AnalyticsService : BaseServices<IAnalyticsServices>, IAnalyticsServices
  {
    const string UrlMicroservice = "http://localhost:5098";

    public AnalyticsService(HttpClientHandler? httpClientHandler = null)
      : base(httpClientHandler)
    {
      CreateChannel(UrlMicroservice);
    }

    public Task<RegisterLevelAnalyticsResponse> RegisterLevelAsync(
      RegisterLevelAnalyticsRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterLevelAsync(request, context);
    }

    public Task<UpdateLevelAnalyticsResponse> UpdateLevelAsync(
      UpdateLevelAnalyticsRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateLevelAsync(request, context);
    }

    public Task<DeleteLevelAnalyticsResponse> DeleteLevelAsync(
      DeleteLevelAnalyticsRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteLevelAsync(request, context);
    }

    public Task<GetLevelsAnalyticsResponse> GetLevelsAsync(
      GetLevelsAnalyticsRequest request,
      CallContext context = default
    )
    {
      return Client.GetLevelsAsync(request, context);
    }
  }
}
