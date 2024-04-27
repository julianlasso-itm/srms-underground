
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

        public async Task<DeleteProfessionalResponse> DeleteProfessionalAsync(DeleteProfessionalRequest request, CallContext context = default)
        {
            DeleteProfessionalHelper.SetApplication(_applicationService.GetApplication());
            return await DeleteProfessionalHelper.DeleteProfessionalAsync(request);
        }

        public async Task<DeleteSkillResponse> DeleteSkillAsync(DeleteSkillRequest request, CallContext context = default)
        {
            DeleteSkillHelper.SetApplication(_applicationService.GetApplication());
            return await DeleteSkillHelper.DeleteSkillAsync(request);
        }

        public async Task<GetProfessionalResponse> GetProfessionalAsync(GetProfessionalsRequest request, CallContext context = default)
        {
            GetProfessionalHelper.SetApplication(_applicationService.GetApplication());
            return await GetProfessionalHelper.GetProfessionalsAsync(request);
        }

        public async Task<GetSkillsResponse> GetSkillAsync(GetSkillsRequest request, CallContext context = default)
        {
            GetSkillsHelper.SetApplication(_applicationService.GetApplication());
            return await GetSkillsHelper.GetSkillsAsync(request);
        }

        public async Task<RegisterProfessionalResponse> RegisterProfessionalAsync(RegisterProfessionalRequest request, CallContext context = default)
        {
            RegisterProfessionalHelper.SetApplication(_applicationService.GetApplication());
            return await RegisterProfessionalHelper.RegisterProfessionalAsync(request);
        }

        public async Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request, CallContext context = default)
        {
            RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
            return await RegisterSkillHelper.RegisterSkillAsync(request);
        }

        public async Task<UpdateProfessionalResponse> UpdateProfessionalAsync(UpdateProfessionalRequest request, CallContext context = default)
        {
            UpdateProfessionalHelper.SetApplication(_applicationService.GetApplication());
            return await UpdateProfessionalHelper.UpdateProfessionalAsync(request);
        }

        public async Task<UpdateSkillResponse> UpdateSkillRoleAsync(UpdateSkillRequest request, CallContext context = default)
        {
            UpdateSkillHelper.SetApplication(_applicationService.GetApplication());
            return await UpdateSkillHelper.UpdateSkillAsync(request);
        }
       
    }
}
