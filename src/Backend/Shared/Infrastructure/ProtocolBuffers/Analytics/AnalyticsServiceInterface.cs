using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Analytics
{
  [ServiceContract]
  public interface IAnalyticsServices
  {
    [OperationContract]
    Task<Result<RegisterLevelAnalyticsResponse>> RegisterLevelAsync(
      RegisterLevelAnalyticsRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateLevelAnalyticsResponse>> UpdateLevelAsync(
      UpdateLevelAnalyticsRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteLevelAnalyticsResponse>> DeleteLevelAsync(
      DeleteLevelAnalyticsRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetLevelsAnalyticsResponse>> GetLevelsAsync(
      GetLevelsAnalyticsRequest request,
      CallContext context = default
    );
  }
}
