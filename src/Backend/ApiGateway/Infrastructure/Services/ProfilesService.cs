using ApiGateway.Infrastructure.Services.Base;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace ApiGateway.Infrastructure.Services
{
    public class ProfilesService: BaseServices<IProfilesServices>, IProfilesServices
    {

        const string UrlMicroservice = "http://localhost:5199";

        public ProfilesService(HttpClientHandler? httpClientHandler = null)
        : base(httpClientHandler)
        {
            CreateChannel(UrlMicroservice);
        }

        public Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request, CallContext context = default)
        {
           return Client.RegisterSkillAsync(request);
        }

        public Task<DeleteSkillResponse> DeleteSkillAsync(DeleteSkillRequest request, CallContext context = default)
        {
            return Client.DeleteSkillAsync(request);
        }

        public Task<GetSkillsResponse> GetSkillAsync(GetSkillsRequest request, CallContext context = default)
        {
            return Client.GetSkillAsync(request);
        }

        public Task<UpdateSkillResponse> UpdateSkillRoleAsync(UpdateSkillRequest request, CallContext context = default)
        {
            return Client.UpdateSkillRoleAsync(request);
        }

        public Task<DeleteProfessionalResponse> DeleteProfessionalAsync(DeleteProfessionalRequest request, CallContext context = default)
        {
            return Client.DeleteProfessionalAsync(request);
        }

        public Task<GetProfessionalResponse> GetProfessionalAsync(GetProfessionalsRequest request, CallContext context = default)
        {
            return Client.GetProfessionalAsync(request);
        }

        public Task<RegisterProfessionalResponse> RegisterProfessionalAsync(RegisterProfessionalRequest request, CallContext context = default)
        {
            return Client.RegisterProfessionalAsync(request);
        }

        public Task<UpdateProfessionalResponse> UpdateProfessionalAsync(UpdateProfessionalRequest request, CallContext context = default)
        {
            return Client.UpdateProfessionalAsync(request);
        }
    }
}
