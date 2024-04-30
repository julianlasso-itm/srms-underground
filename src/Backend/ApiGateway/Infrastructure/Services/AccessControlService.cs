using ApiGateway.Infrastructure.Services.Base;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace ApiGateway.Infrastructure.Services
{
  public class AccessControlService : BaseServices<IAccessControlServices>, IAccessControlServices
  {
    const string UrlMicroservice = "http://localhost:5297";

    public AccessControlService(HttpClientHandler? httpClientHandler = null)
      : base(httpClientHandler)
    {
      CreateChannel(UrlMicroservice);
    }

    public Task<RegisterRoleSecurityResponse> RegisterRoleAsync(
      RegisterRoleSecurityRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterRoleAsync(request, context);
    }

    public Task<UpdateRoleSecurityResponse> UpdateRoleAsync(
      UpdateRoleSecurityRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateRoleAsync(request, context);
    }

    public Task<DeleteRoleSecurityResponse> DeleteRoleAsync(
      DeleteRoleSecurityRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteRoleAsync(request, context);
    }

    public Task<GetRolesSecurityResponse> GetRolesAsync(
      GetRolesSecurityRequest request,
      CallContext context = default
    )
    {
      return Client.GetRolesAsync(request, context);
    }
  }
}
