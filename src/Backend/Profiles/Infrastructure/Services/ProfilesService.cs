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

    public Task<DeleteCityResponse> DeleteCityAsync(
      DeleteCityRequest request,
      CallContext context = default
    )
    {
      DeleteCityHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCityHelper.DeleteCityAsync(request);
    }

    public Task<DeleteCountryResponse> DeleteCountryAsync(
      DeleteCountryRequest request,
      CallContext context = default
    )
    {
      DeleteCountryHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCountryHelper.DeleteCountryAsync(request);
    }

    public Task<DeleteProvinceResponse> DeleteProvinceAsync(
      DeleteProvinceRequest request,
      CallContext context = default
    )
    {
      DeleteProvinceHelper.SetApplication(_applicationService.GetApplication());
      return DeleteProvinceHelper.DeleteProvinceAsync(request);
    }

    public Task<GetCitiesResponse> GetCitiesAsync(
      GetCitiesRequest request,
      CallContext context = default
    )
    {
      GetCitiesHelper.SetApplication(_applicationService.GetApplication());
      return GetCitiesHelper.GetCitiesAsync(request);
    }

    public Task<GetCountriesResponse> GetCountriesAsync(
      GetCountriesRequest request,
      CallContext context = default
    )
    {
      GetCountriesHelper.SetApplication(_applicationService.GetApplication());
      return GetCountriesHelper.GetCountriesAsync(request);
    }

    public Task<GetProvincesResponse> GetProvincesAsync(
      GetProvincesRequest request,
      CallContext context = default
    )
    {
      GetProvincesHelper.SetApplication(_applicationService.GetApplication());
      return GetProvincesHelper.GetProvincesAsync(request);
    }

    public Task<RegisterCityResponse> RegisterCityAsync(
      RegisterCityRequest request,
      CallContext context = default
    )
    {
      RegisterCityHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCityHelper.RegisterCityAsync(request);
    }

    public Task<RegisterCountryResponse> RegisterCountryAsync(
      RegisterCountryRequest request,
      CallContext context = default
    )
    {
      RegisterCountryHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCountryHelper.RegisterCountryAsync(request);
    }

    public Task<RegisterProvinceResponse> RegisterProvinceAsync(
      RegisterProvinceRequest request,
      CallContext context = default
    )
    {
      RegisterProvinceHelper.SetApplication(_applicationService.GetApplication());
      return RegisterProvinceHelper.RegisterProvinceAsync(request);
    }

    public Task<UpdateCityResponse> UpdateCityAsync(
      UpdateCityRequest request,
      CallContext context = default
    )
    {
      UpdateCityHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCityHelper.UpdateCityAsync(request);
    }

    public Task<UpdateCountryResponse> UpdateCountryAsync(
      UpdateCountryRequest request,
      CallContext context = default
    )
    {
      UpdateCountryHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCountryHelper.UpdateCountryAsync(request);
    }

    public Task<UpdateProvinceResponse> UpdateProvinceAsync(
      UpdateProvinceRequest request,
      CallContext context = default
    )
    {
      UpdateProvinceHelper.SetApplication(_applicationService.GetApplication());
      return UpdateProvinceHelper.UpdateProvinceAsync(request);
    }

    public Task<DeleteRoleResponse> DeleteRoleAsync(
      DeleteRoleRequest request,
      CallContext context = default
    )
    {
      DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
      return DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public Task<GetRolesResponse> GetRolesAsync(
      GetRolesRequest request,
      CallContext context = default
    )
    {
      GetRolesHelper.SetApplication(_applicationService.GetApplication());
      return GetRolesHelper.GetRolesAsync(request);
    }

    public Task<RegisterRoleResponse> RegisterRoleAsync(
      RegisterRoleRequest request,
      CallContext context = default
    )
    {
      RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
      return RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public Task<UpdateRoleResponse> UpdateRoleAsync(
      UpdateRoleRequest request,
      CallContext context = default
    )
    {
      UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
      return UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<DeleteProfessionalResponse> DeleteProfessionalAsync(
      DeleteProfessionalRequest request,
      CallContext context = default
    )
    {
      DeleteProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteProfessionalHelper.DeleteProfessionalAsync(request);
    }

    public async Task<DeleteSkillResponse> DeleteSkillAsync(
      DeleteSkillRequest request,
      CallContext context = default
    )
    {
      DeleteSkillHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteSkillHelper.DeleteSkillAsync(request);
    }

    public async Task<GetProfessionalResponse> GetProfessionalAsync(
      GetProfessionalsRequest request,
      CallContext context = default
    )
    {
      GetProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await GetProfessionalHelper.GetProfessionalsAsync(request);
    }

    public async Task<GetSkillsResponse> GetSkillAsync(
      GetSkillsRequest request,
      CallContext context = default
    )
    {
      GetSkillsHelper.SetApplication(_applicationService.GetApplication());
      return await GetSkillsHelper.GetSkillsAsync(request);
    }

    public async Task<RegisterProfessionalResponse> RegisterProfessionalAsync(
      RegisterProfessionalRequest request,
      CallContext context = default
    )
    {
      RegisterProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterProfessionalHelper.RegisterProfessionalAsync(request);
    }

    public async Task<RegisterSkillResponse> RegisterSkillAsync(
      RegisterSkillRequest request,
      CallContext context = default
    )
    {
      RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterSkillHelper.RegisterSkillAsync(request);
    }

    public async Task<UpdateProfessionalResponse> UpdateProfessionalAsync(
      UpdateProfessionalRequest request,
      CallContext context = default
    )
    {
      UpdateProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateProfessionalHelper.UpdateProfessionalAsync(request);
    }

    public async Task<UpdateSkillResponse> UpdateSkillRoleAsync(
      UpdateSkillRequest request,
      CallContext context = default
    )
    {
      UpdateSkillHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateSkillHelper.UpdateSkillAsync(request);
    }
  }
}
