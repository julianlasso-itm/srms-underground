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

        public Task<DeleteCityResponse> DeleteCityAsync(
            DeleteCityRequest request,
            CallContext context = default
        )
        {
            return Client.DeleteCityAsync(request, context);
        }

        public Task<DeleteCountryResponse> DeleteCountryAsync(
            DeleteCountryRequest request,
            CallContext context = default
        )
        {
            return Client.DeleteCountryAsync(request, context);
        }

        public Task<DeleteProvinceResponse> DeleteProvinceAsync(
            DeleteProvinceRequest request,
            CallContext context = default
        )
        {
            return Client.DeleteProvinceAsync(request, context);
        }

        public Task<GetCitiesResponse> GetCitiesAsync(
            GetCitiesRequest request,
            CallContext context = default
        )
        {
            return Client.GetCitiesAsync(request, context);
        }

        public Task<GetCountriesResponse> GetCountriesAsync(
            GetCountriesRequest request,
            CallContext context = default
        )
        {
            return Client.GetCountriesAsync(request, context);
        }

        public Task<GetProvincesResponse> GetProvincesAsync(
            GetProvincesRequest request,
            CallContext context = default
        )
        {
            return Client.GetProvincesAsync(request, context);
        }

        public Task<RegisterCityResponse> RegisterCityAsync(
            RegisterCityRequest request,
            CallContext context = default
        )
        {
            return Client.RegisterCityAsync(request, context);
        }

        public Task<RegisterCountryResponse> RegisterCountryAsync(
            RegisterCountryRequest request,
            CallContext context = default
        )
        {
            return Client.RegisterCountryAsync(request, context);
        }

        public Task<RegisterProvinceResponse> RegisterProvinceAsync(
            RegisterProvinceRequest request,
            CallContext context = default
        )
        {
            return Client.RegisterProvinceAsync(request, context);
        }

        public Task<UpdateCityResponse> UpdateCityAsync(
            UpdateCityRequest request,
            CallContext context = default
        )
        {
            return Client.UpdateCityAsync(request, context);
        }

        public Task<UpdateCountryResponse> UpdateCountryAsync(
            UpdateCountryRequest request,
            CallContext context = default
        )
        {
            return Client.UpdateCountryAsync(request, context);
        }

        public Task<UpdateProvinceResponse> UpdateProvinceAsync(
            UpdateProvinceRequest request,
            CallContext context = default
        )
        {
            return Client.UpdateProvinceAsync(request, context);
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

        public Task<RegisterSkillResponse> RegisterSkillAsync(
            RegisterSkillRequest request,
            CallContext context = default
        )
        {
            return Client.RegisterSkillAsync(request);
        }

        public Task<DeleteSkillResponse> DeleteSkillAsync(
            DeleteSkillRequest request,
            CallContext context = default
        )
        {
            return Client.DeleteSkillAsync(request);
        }

        public Task<GetSkillsResponse> GetSkillAsync(
            GetSkillsRequest request,
            CallContext context = default
        )
        {
            return Client.GetSkillAsync(request);
        }

        public Task<UpdateSkillResponse> UpdateSkillRoleAsync(
            UpdateSkillRequest request,
            CallContext context = default
        )
        {
            return Client.UpdateSkillRoleAsync(request);
        }

        public Task<DeleteProfessionalResponse> DeleteProfessionalAsync(
            DeleteProfessionalRequest request,
            CallContext context = default
        )
        {
            return Client.DeleteProfessionalAsync(request);
        }

        public Task<GetProfessionalResponse> GetProfessionalAsync(
            GetProfessionalsRequest request,
            CallContext context = default
        )
        {
            return Client.GetProfessionalAsync(request);
        }

        public Task<RegisterProfessionalResponse> RegisterProfessionalAsync(
            RegisterProfessionalRequest request,
            CallContext context = default
        )
        {
            return Client.RegisterProfessionalAsync(request);
        }

        public Task<UpdateProfessionalResponse> UpdateProfessionalAsync(
            UpdateProfessionalRequest request,
            CallContext context = default
        )
        {
            return Client.UpdateProfessionalAsync(request);
        }
    }
}
