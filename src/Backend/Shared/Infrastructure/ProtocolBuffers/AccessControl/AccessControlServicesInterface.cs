using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl;

[ServiceContract]
public interface IAccessControlServices
{
    [OperationContract]
    Task<RegisterUserResponse> RegisterUserAsync(
        RegisterUserRequest request,
        CallContext context = default
    );

    [OperationContract]
    Task<RegisterRoleResponse> RegisterRoleAsync(
        RegisterRoleRequest request,
        CallContext context = default
    );

    [OperationContract]
    Task<UpdateRoleResponse> UpdateRoleAsync(
        UpdateRoleRequest request,
        CallContext context = default
    );

    [OperationContract]
    Task<DeleteRoleResponse> DeleteRoleAsync(
        DeleteRoleRequest request,
        CallContext context = default
    );

    [OperationContract]
    Task<GetRolesResponse> GetRolesAsync(
        GetRolesRequest request,
        CallContext context = default
    );
}
