using Profiles.Infrastructure.Services.helpers;
using Profiles.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services
{
    public class ProfilesService : IProfilesServices
    {
        private readonly ApplicationService _applicationService;

        public ProfilesService(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public Task<DeleteRoleResponse> DeleteRoleAsync(
            DeleteRoleRequest request,
            CallContext context = default
        )
        {
            DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
            return DeleteRoleHelper.DeleteRoleAsync(request);
        }

        public Task<GetRolesResponse> GetRolesAsync(
            GetRolesRequest request,
            CallContext context = default
        )
        {
            GetRolesHelper.SetApplication(_applicationService.GetApplication());
            return GetRolesHelper.GetRolesAsync(request);
        }

        public Task<RegisterRoleResponse> RegisterRoleAsync(
            RegisterRoleRequest request,
            CallContext context = default
        )
        {
            RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
            return RegisterRoleHelper.RegisterRoleAsync(request);
        }

        public Task<UpdateRoleResponse> UpdateRoleAsync(
            UpdateRoleRequest request,
            CallContext context = default
        )
        {
            UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
            return UpdateRoleHelper.UpdateRoleAsync(request);
        }
    }
}
