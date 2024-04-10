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
}
