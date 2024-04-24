
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

        public async Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request, CallContext context = default)
        {
            RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
            return await RegisterSkillHelper.RegisterSkillAsync(request);
        }
    }
}
