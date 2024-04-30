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
    Task<RegisterLevelSecurityResponse> RegisterLevelAsync(
      RegisterLevelSecurityRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateLevelSecurityResponse> UpdateLevelAsync(
      UpdateLevelSecurityRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteLevelSecurityResponse> DeleteLevelAsync(
      DeleteLevelSecurityRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetLevelsSecurityResponse> GetLevelsAsync(
      GetLevelsSecurityRequest request,
      CallContext context = default
    );
  }
}
