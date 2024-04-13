using ApiGateway.Infrastructure.Services.Base;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace ApiGateway.Infrastructure.Services;

public class AccessControlService : BaseServices<IAccessControlServices>, IAccessControlServices
{
    const string UrlMicroservice = "http://localhost:5297";

    public AccessControlService(HttpClientHandler? httpClientHandler = null)
        : base(httpClientHandler)
    {
        CreateChannel(UrlMicroservice);
    }

    public Task<RegisterRoleResponse> RegisterRoleAsync(
        RegisterRoleRequest request,
        CallContext context = default
    )
    {
        return Client.RegisterRoleAsync(request, context);
    }

    public Task<RegisterUserResponse> RegisterUserAsync(
        RegisterUserRequest request,
        CallContext context = default
    )
    {
        return Client.RegisterUserAsync(request, context);
    }

    public Task<UpdateRoleResponse> UpdateRoleAsync(
        UpdateRoleRequest request,
        CallContext context = default
    )
    {
        return Client.UpdateRoleAsync(request, context);
    }
}
