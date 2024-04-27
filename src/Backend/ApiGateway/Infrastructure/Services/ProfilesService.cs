using ApiGateway.Infrastructure.Services.Base;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace ApiGateway.Infrastructure.Services
{
    public class ProfilesService : BaseServices<IProfilesServices>, IProfilesServices
    {
        const string UrlMicroservice = "http://localhost:5199";

        public ProfilesService(HttpClientHandler? httpClientHandler = null)
            : base(httpClientHandler)
        {
            CreateChannel(UrlMicroservice);
        }

        public Task<RegisterRoleResponse> RegisterRoleAsync(
            RegisterRoleRequest request,
            CallContext context = default
        )
        {
            return Client.RegisterRoleAsync(request);
        }

        public Task<UpdateRoleResponse> UpdateRoleAsync(
            UpdateRoleRequest request,
            CallContext context = default
        )
        {
            return Client.UpdateRoleAsync(request);
        }

        public Task<DeleteRoleResponse> DeleteRoleAsync(
            DeleteRoleRequest request,
            CallContext context = default
        )
        {
            return Client.DeleteRoleAsync(request);
        }

        public Task<GetRolesResponse> GetRolesAsync(
            GetRolesRequest request,
            CallContext context = default
        )
        {
            return Client.GetRolesAsync(request);
        }
    }
}
