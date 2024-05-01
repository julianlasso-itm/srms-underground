using Profiles.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services
{
  internal class ProfilesService : IProfilesServices
  {
    private readonly ApplicationService _applicationService;

    public ProfilesService(ApplicationService applicationService)
    {
      _applicationService = applicationService;
    }

    public Task<DeleteCityProfilesResponse> DeleteCityAsync(
      DeleteCityProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteCityHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCityHelper.DeleteCityAsync(request);
    }

    public Task<DeleteCountryProfilesResponse> DeleteCountryAsync(
      DeleteCountryProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteCountryHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCountryHelper.DeleteCountryAsync(request);
    }

    public Task<DeleteProvinceProfilesResponse> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteProvinceHelper.SetApplication(_applicationService.GetApplication());
      return DeleteProvinceHelper.DeleteProvinceAsync(request);
    }

    public Task<GetCitiesProfilesResponse> GetCitiesAsync(
      GetCitiesProfilesRequest request,
      CallContext context = default
    )
    {
      GetCitiesHelper.SetApplication(_applicationService.GetApplication());
      return GetCitiesHelper.GetCitiesAsync(request);
    }

    public Task<GetCountriesProfilesResponse> GetCountriesAsync(
      GetCountriesProfilesRequest request,
      CallContext context = default
    )
    {
      GetCountriesHelper.SetApplication(_applicationService.GetApplication());
      return GetCountriesHelper.GetCountriesAsync(request);
    }

    public Task<GetProvincesProfilesResponse> GetProvincesAsync(
      GetProvincesProfilesRequest request,
      CallContext context = default
    )
    {
      GetProvincesHelper.SetApplication(_applicationService.GetApplication());
      return GetProvincesHelper.GetProvincesAsync(request);
    }

    public Task<RegisterCityProfilesResponse> RegisterCityAsync(
      RegisterCityProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterCityHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCityHelper.RegisterCityAsync(request);
    }

    public Task<RegisterCountryProfilesResponse> RegisterCountryAsync(
      RegisterCountryProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterCountryHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCountryHelper.RegisterCountryAsync(request);
    }

    public Task<RegisterProvinceProfilesResponse> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterProvinceHelper.SetApplication(_applicationService.GetApplication());
      return RegisterProvinceHelper.RegisterProvinceAsync(request);
    }

    public Task<UpdateCityProfilesResponse> UpdateCityAsync(
      UpdateCityProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateCityHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCityHelper.UpdateCityAsync(request);
    }

    public Task<UpdateCountryProfilesResponse> UpdateCountryAsync(
      UpdateCountryProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateCountryHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCountryHelper.UpdateCountryAsync(request);
    }

    public Task<UpdateProvinceProfilesResponse> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateProvinceHelper.SetApplication(_applicationService.GetApplication());
      return UpdateProvinceHelper.UpdateProvinceAsync(request);
    }

    public Task<DeleteRoleProfilesResponse> DeleteRoleAsync(
      DeleteRoleProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
      return DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public Task<GetRolesProfilesResponse> GetRolesAsync(
      GetRolesProfilesRequest request,
      CallContext context = default
    )
    {
      GetRolesHelper.SetApplication(_applicationService.GetApplication());
      return GetRolesHelper.GetRolesAsync(request);
    }

    public Task<RegisterRoleProfilesResponse> RegisterRoleAsync(
      RegisterRoleProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
      return RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public Task<UpdateRoleProfilesResponse> UpdateRoleAsync(
      UpdateRoleProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
      return UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<DeleteProfessionalProfilesResponse> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteProfessionalHelper.DeleteProfessionalAsync(request);
    }

    public async Task<DeleteSkillProfilesResponse> DeleteSkillAsync(
      DeleteSkillProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteSkillHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteSkillHelper.DeleteSkillAsync(request);
    }

    public async Task<GetProfessionalProfilesResponse> GetProfessionalAsync(
      GetProfessionalsProfilesRequest request,
      CallContext context = default
    )
    {
      GetProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await GetProfessionalHelper.GetProfessionalsAsync(request);
    }

    public async Task<GetSkillsProfilesResponse> GetSkillAsync(
      GetSkillsProfilesRequest request,
      CallContext context = default
    )
    {
      GetSkillsHelper.SetApplication(_applicationService.GetApplication());
      return await GetSkillsHelper.GetSkillsAsync(request);
    }

    public async Task<RegisterProfessionalProfilesResponse> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterProfessionalHelper.RegisterProfessionalAsync(request);
    }

    public async Task<RegisterSkillProfilesResponse> RegisterSkillAsync(
      RegisterSkillProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterSkillHelper.RegisterSkillAsync(request);
    }

    public async Task<UpdateProfessionalProfilesResponse> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateProfessionalHelper.UpdateProfessionalAsync(request);
    }

    public async Task<UpdateSkillProfilesResponse> UpdateSkillRoleAsync(
      UpdateSkillProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateSkillHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateSkillHelper.UpdateSkillAsync(request);
    }
  }
}
