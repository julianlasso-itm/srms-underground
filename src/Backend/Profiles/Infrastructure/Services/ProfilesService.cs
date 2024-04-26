
using Profiles.Infrastructure.Services.helpers;
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

        public async Task<DeleteSkillResponse> DeleteSkillAsync(DeleteSkillRequest request, CallContext context = default)
        {
            DeleteSkillHelper.SetApplication(_applicationService.GetApplication());
            return await DeleteSkillHelper.DeleteSkillAsync(request);
        }

        public async Task<GetSkillsResponse> GetSkillAsync(GetSkillsRequest request, CallContext context = default)
        {
            GetSkillsHelper.SetApplication(_applicationService.GetApplication());
            return await GetSkillsHelper.GetSkillsAsync(request);
        }

        public async Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request, CallContext context = default)
        {
            RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
            return await RegisterSkillHelper.RegisterSkillAsync(request);
        }

        public async Task<UpdateSkillResponse> UpdateSkillRoleAsync(UpdateSkillRequest request, CallContext context = default)
        {
            UpdateSkillHelper.SetApplication(_applicationService.GetApplication());
            return await UpdateSkillHelper.UpdateSkillAsync(request);
        }
    }
}
