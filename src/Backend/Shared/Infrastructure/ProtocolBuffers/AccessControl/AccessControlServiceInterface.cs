using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl
{
  [ServiceContract]
  public interface IAccessControlServices
  {
    [OperationContract]
    Task<RegisterRoleSecurityResponse> RegisterRoleAsync(
      RegisterRoleSecurityRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateRoleSecurityResponse> UpdateRoleAsync(
      UpdateRoleSecurityRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteRoleSecurityResponse> DeleteRoleAsync(
      DeleteRoleSecurityRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetRolesSecurityResponse> GetRolesAsync(
      GetRolesSecurityRequest request,
      CallContext context = default
    );
  }
}
