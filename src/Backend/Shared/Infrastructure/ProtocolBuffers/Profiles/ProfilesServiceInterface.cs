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
    Task<GetCountriesProfilesResponse> GetCountriesAsync(
      GetCountriesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<RegisterCountryProfilesResponse> RegisterCountryAsync(
      RegisterCountryProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateCountryProfilesResponse> UpdateCountryAsync(
      UpdateCountryProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteCountryProfilesResponse> DeleteCountryAsync(
      DeleteCountryProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetProvincesProfilesResponse> GetProvincesAsync(
      GetProvincesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<RegisterProvinceProfilesResponse> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateProvinceProfilesResponse> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteProvinceProfilesResponse> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetCitiesProfilesResponse> GetCitiesAsync(
      GetCitiesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<RegisterCityProfilesResponse> RegisterCityAsync(
      RegisterCityProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateCityProfilesResponse> UpdateCityAsync(
      UpdateCityProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteCityProfilesResponse> DeleteCityAsync(
      DeleteCityProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<RegisterRoleProfilesResponse> RegisterRoleAsync(
      RegisterRoleProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateRoleProfilesResponse> UpdateRoleAsync(
      UpdateRoleProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteRoleProfilesResponse> DeleteRoleAsync(
      DeleteRoleProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetRolesProfilesResponse> GetRolesAsync(
      GetRolesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteSkillProfilesResponse> DeleteSkillAsync(
      DeleteSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetSkillsProfilesResponse> GetSkillAsync(
      GetSkillsProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<RegisterSkillProfilesResponse> RegisterSkillAsync(
      RegisterSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateSkillProfilesResponse> UpdateSkillRoleAsync(
      UpdateSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteProfessionalProfilesResponse> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetProfessionalProfilesResponse> GetProfessionalAsync(
      GetProfessionalsProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<RegisterProfessionalProfilesResponse> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateProfessionalProfilesResponse> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request,
      CallContext context = default
    );
  }
}
