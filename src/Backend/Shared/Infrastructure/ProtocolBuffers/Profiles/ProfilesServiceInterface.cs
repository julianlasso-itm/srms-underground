using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles
{
    [ServiceContract]
    public interface IProfilesServices
    {
        [OperationContract]
        Task<GetCountriesResponse> GetCountriesAsync(
            GetCountriesRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<RegisterCountryResponse> RegisterCountryAsync(
            RegisterCountryRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<UpdateCountryResponse> UpdateCountryAsync(
            UpdateCountryRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<DeleteCountryResponse> DeleteCountryAsync(
            DeleteCountryRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<GetProvincesResponse> GetProvincesAsync(
            GetProvincesRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<RegisterProvinceResponse> RegisterProvinceAsync(
            RegisterProvinceRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<UpdateProvinceResponse> UpdateProvinceAsync(
            UpdateProvinceRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<DeleteProvinceResponse> DeleteProvinceAsync(
            DeleteProvinceRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<GetCitiesResponse> GetCitiesAsync(
            GetCitiesRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<RegisterCityResponse> RegisterCityAsync(
            RegisterCityRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<UpdateCityResponse> UpdateCityAsync(
            UpdateCityRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<DeleteCityResponse> DeleteCityAsync(
            DeleteCityRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<RegisterRoleResponse> RegisterRoleAsync(
            RegisterRoleRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<UpdateRoleResponse> UpdateRoleAsync(
            UpdateRoleRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<DeleteRoleResponse> DeleteRoleAsync(
            DeleteRoleRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<GetRolesResponse> GetRolesAsync(
            GetRolesRequest request,
            CallContext context = default
        );

        [OperationContract]
        Task<DeleteSkillResponse> DeleteSkillAsync(DeleteSkillRequest request, CallContext context = default);

        [OperationContract]
        Task<GetSkillsResponse> GetSkillAsync(GetSkillsRequest request, CallContext context = default);

        [OperationContract]
        Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request, CallContext context = default);

        [OperationContract]
        Task<UpdateSkillResponse> UpdateSkillRoleAsync(UpdateSkillRequest request, CallContext context = default);

        [OperationContract]
        Task<DeleteProfessionalResponse> DeleteProfessionalAsync(DeleteProfessionalRequest request, CallContext context = default);

        [OperationContract]
        Task<GetProfessionalResponse> GetProfessionalAsync(GetProfessionalsRequest request, CallContext context = default);

        [OperationContract]
        Task<RegisterProfessionalResponse> RegisterProfessionalAsync(RegisterProfessionalRequest request, CallContext context = default);

        [OperationContract]
        Task<UpdateProfessionalResponse> UpdateProfessionalAsync(UpdateProfessionalRequest request, CallContext context = default);
    }
}
