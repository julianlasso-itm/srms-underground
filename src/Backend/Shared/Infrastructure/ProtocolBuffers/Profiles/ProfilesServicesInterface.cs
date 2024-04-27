using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles
{
    [ServiceContract]
    public interface IProfilesServices
    {
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
}
