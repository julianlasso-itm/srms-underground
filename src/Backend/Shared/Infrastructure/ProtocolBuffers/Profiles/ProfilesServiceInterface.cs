using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles
{
  [ServiceContract]
  public interface IProfilesServices
  {
    [OperationContract]
    Task<Result<GetCountriesProfilesResponse>> GetCountriesAsync(
      GetCountriesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterCountryProfilesResponse>> RegisterCountryAsync(
      RegisterCountryProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateCountryProfilesResponse>> UpdateCountryAsync(
      UpdateCountryProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteCountryProfilesResponse>> DeleteCountryAsync(
      DeleteCountryProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetProvincesProfilesResponse>> GetProvincesAsync(
      GetProvincesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterProvinceProfilesResponse>> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateProvinceProfilesResponse>> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteProvinceProfilesResponse>> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetCitiesProfilesResponse>> GetCitiesAsync(
      GetCitiesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterCityProfilesResponse>> RegisterCityAsync(
      RegisterCityProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateCityProfilesResponse>> UpdateCityAsync(
      UpdateCityProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteCityProfilesResponse>> DeleteCityAsync(
      DeleteCityProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterRoleProfilesResponse>> RegisterRoleAsync(
      RegisterRoleProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateRoleProfilesResponse>> UpdateRoleAsync(
      UpdateRoleProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteRoleProfilesResponse>> DeleteRoleAsync(
      DeleteRoleProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetRolesProfilesResponse>> GetRolesAsync(
      GetRolesProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteSkillProfilesResponse>> DeleteSkillAsync(
      DeleteSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetSkillsProfilesResponse>> GetSkillAsync(
      GetSkillsProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterSkillProfilesResponse>> RegisterSkillAsync(
      RegisterSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateSkillProfilesResponse>> UpdateSkillRoleAsync(
      UpdateSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteProfessionalProfilesResponse>> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetProfessionalProfilesResponse>> GetProfessionalAsync(
      GetProfessionalsProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterProfessionalProfilesResponse>> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateProfessionalProfilesResponse>> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterSubSkillProfilesResponse>> RegisterSubSkillAsync(
      RegisterSubSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateSubSkillProfilesResponse>> UpdateSubSkillAsync(
      UpdateSubSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteSubSkillProfilesResponse>> DeleteSubSkillAsync(
      DeleteSubSkillProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetSubSkillsProfilesResponse>> GetSubSkillsAsync(
      GetSubSkillsProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterSquadProfilesResponse>> RegisterSquadAsync(
      RegisterSquadProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateSquadProfilesResponse>> UpdateSquadAsync(
      UpdateSquadProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteSquadProfilesResponse>> DeleteSquadAsync(
      DeleteSquadProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetSquadsProfilesResponse>> GetSquadsAsync(
      GetSquadsProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterAssessmentProfilesResponse>> RegisterAssessmentAsync(
      RegisterAssessmentProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateAssessmentProfilesResponse>> UpdateAssessmentAsync(
      UpdateAssessmentProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteAssessmentProfilesResponse>> DeleteAssessmentAsync(
      DeleteAssessmentProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetAssessmentsProfilesResponse>> GetAssessmentsAsync(
      GetAssessmentsProfilesRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetPodiumProfilesResponse>> GetPodiumsAsync(
      GetPodiumProfilesRequest request,
      CallContext context = default
    );
  }
}
