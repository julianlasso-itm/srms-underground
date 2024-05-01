using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics
{
  [ServiceContract]
  public interface IAnalyticsServices
  {
    [OperationContract]
    Task<RegisterLevelAnalyticsResponse> RegisterLevelAsync(
      RegisterLevelAnalyticsRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateLevelAnalyticsResponse> UpdateLevelAsync(
      UpdateLevelAnalyticsRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteLevelAnalyticsResponse> DeleteLevelAsync(
      DeleteLevelAnalyticsRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetLevelsAnalyticsResponse> GetLevelsAsync(
      GetLevelsAnalyticsRequest request,
      CallContext context = default
    );
  }
}
