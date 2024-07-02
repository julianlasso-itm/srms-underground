using ApiGateway.Infrastructure.Services.Base;
using ProtoBuf.Grpc;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace ApiGateway.Infrastructure.Services
{
  public class ProfilesService : BaseServices<IProfilesServices>, IProfilesServices
  {
    public ProfilesService(string urlMicroservice, HttpClientHandler? httpClientHandler = null)
      : base(httpClientHandler)
    {
      CreateChannel(urlMicroservice);
    }

    public Task<Result<DeleteCityProfilesResponse>> DeleteCityAsync(
      DeleteCityProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteCityAsync(request, context);
    }

    public Task<Result<DeleteCountryProfilesResponse>> DeleteCountryAsync(
      DeleteCountryProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteCountryAsync(request, context);
    }

    public Task<Result<DeleteProvinceProfilesResponse>> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteProvinceAsync(request, context);
    }

    public Task<Result<GetCitiesProfilesResponse>> GetCitiesAsync(
      GetCitiesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetCitiesAsync(request, context);
    }

    public Task<Result<GetCountriesProfilesResponse>> GetCountriesAsync(
      GetCountriesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetCountriesAsync(request, context);
    }

    public Task<Result<GetProvincesProfilesResponse>> GetProvincesAsync(
      GetProvincesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetProvincesAsync(request, context);
    }

    public Task<Result<RegisterCityProfilesResponse>> RegisterCityAsync(
      RegisterCityProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterCityAsync(request, context);
    }

    public Task<Result<RegisterCountryProfilesResponse>> RegisterCountryAsync(
      RegisterCountryProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterCountryAsync(request, context);
    }

    public Task<Result<RegisterProvinceProfilesResponse>> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterProvinceAsync(request, context);
    }

    public Task<Result<UpdateCityProfilesResponse>> UpdateCityAsync(
      UpdateCityProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateCityAsync(request, context);
    }

    public Task<Result<UpdateCountryProfilesResponse>> UpdateCountryAsync(
      UpdateCountryProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateCountryAsync(request, context);
    }

    public Task<Result<UpdateProvinceProfilesResponse>> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateProvinceAsync(request, context);
    }

    public Task<Result<RegisterRoleProfilesResponse>> RegisterRoleAsync(
      RegisterRoleProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterRoleAsync(request);
    }

    public Task<Result<UpdateRoleProfilesResponse>> UpdateRoleAsync(
      UpdateRoleProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateRoleAsync(request);
    }

    public Task<Result<DeleteRoleProfilesResponse>> DeleteRoleAsync(
      DeleteRoleProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteRoleAsync(request);
    }

    public Task<Result<GetRolesProfilesResponse>> GetRolesAsync(
      GetRolesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetRolesAsync(request);
    }

    public Task<Result<RegisterSkillProfilesResponse>> RegisterSkillAsync(
      RegisterSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterSkillAsync(request);
    }

    public Task<Result<DeleteSkillProfilesResponse>> DeleteSkillAsync(
      DeleteSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteSkillAsync(request);
    }

    public Task<Result<GetSkillsProfilesResponse>> GetSkillAsync(
      GetSkillsProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetSkillAsync(request);
    }

    public Task<Result<UpdateSkillProfilesResponse>> UpdateSkillRoleAsync(
      UpdateSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateSkillRoleAsync(request);
    }

    public Task<Result<DeleteProfessionalProfilesResponse>> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteProfessionalAsync(request);
    }

    public Task<Result<GetProfessionalProfilesResponse>> GetProfessionalAsync(
      GetProfessionalsProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetProfessionalAsync(request);
    }

    public Task<Result<RegisterProfessionalProfilesResponse>> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterProfessionalAsync(request);
    }

    public Task<Result<UpdateProfessionalProfilesResponse>> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateProfessionalAsync(request);
    }

    public Task<Result<RegisterSubSkillProfilesResponse>> RegisterSubSkillAsync(
      RegisterSubSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterSubSkillAsync(request);
    }

    public Task<Result<UpdateSubSkillProfilesResponse>> UpdateSubSkillAsync(
      UpdateSubSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateSubSkillAsync(request);
    }

    public Task<Result<DeleteSubSkillProfilesResponse>> DeleteSubSkillAsync(
      DeleteSubSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteSubSkillAsync(request);
    }

    public Task<Result<GetSubSkillsProfilesResponse>> GetSubSkillsAsync(
      GetSubSkillsProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetSubSkillsAsync(request);
    }

    public Task<Result<RegisterSquadProfilesResponse>> RegisterSquadAsync(
      RegisterSquadProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterSquadAsync(request);
    }

    public Task<Result<UpdateSquadProfilesResponse>> UpdateSquadAsync(
      UpdateSquadProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateSquadAsync(request);
    }

    public Task<Result<DeleteSquadProfilesResponse>> DeleteSquadAsync(
      DeleteSquadProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteSquadAsync(request);
    }

    public Task<Result<GetSquadsProfilesResponse>> GetSquadsAsync(
      GetSquadsProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetSquadsAsync(request);
    }

    public Task<Result<RegisterAssessmentProfilesResponse>> RegisterAssessmentAsync(
      RegisterAssessmentProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterAssessmentAsync(request);
    }

    public Task<Result<UpdateAssessmentProfilesResponse>> UpdateAssessmentAsync(
      UpdateAssessmentProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateAssessmentAsync(request);
    }

    public Task<Result<DeleteAssessmentProfilesResponse>> DeleteAssessmentAsync(
      DeleteAssessmentProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteAssessmentAsync(request);
    }

    public Task<Result<GetAssessmentsProfilesResponse>> GetAssessmentsAsync(
      GetAssessmentsProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetAssessmentsAsync(request);
    }

    public Task<Result<GetPodiumProfilesResponse>> GetPodiumsAsync(
      GetPodiumProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetPodiumsAsync(request);
    }
  }
}
