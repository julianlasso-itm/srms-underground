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

    public Task<DeleteCityProfilesResponse> DeleteCityAsync(
      DeleteCityProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteCityAsync(request, context);
    }

    public Task<DeleteCountryProfilesResponse> DeleteCountryAsync(
      DeleteCountryProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteCountryAsync(request, context);
    }

    public Task<DeleteProvinceProfilesResponse> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteProvinceAsync(request, context);
    }

    public Task<GetCitiesProfilesResponse> GetCitiesAsync(
      GetCitiesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetCitiesAsync(request, context);
    }

    public Task<GetCountriesProfilesResponse> GetCountriesAsync(
      GetCountriesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetCountriesAsync(request, context);
    }

    public Task<GetProvincesProfilesResponse> GetProvincesAsync(
      GetProvincesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetProvincesAsync(request, context);
    }

    public Task<RegisterCityProfilesResponse> RegisterCityAsync(
      RegisterCityProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterCityAsync(request, context);
    }

    public Task<RegisterCountryProfilesResponse> RegisterCountryAsync(
      RegisterCountryProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterCountryAsync(request, context);
    }

    public Task<RegisterProvinceProfilesResponse> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterProvinceAsync(request, context);
    }

    public Task<UpdateCityProfilesResponse> UpdateCityAsync(
      UpdateCityProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateCityAsync(request, context);
    }

    public Task<UpdateCountryProfilesResponse> UpdateCountryAsync(
      UpdateCountryProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateCountryAsync(request, context);
    }

    public Task<UpdateProvinceProfilesResponse> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateProvinceAsync(request, context);
    }

    public Task<RegisterRoleProfilesResponse> RegisterRoleAsync(
      RegisterRoleProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterRoleAsync(request);
    }

    public Task<UpdateRoleProfilesResponse> UpdateRoleAsync(
      UpdateRoleProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateRoleAsync(request);
    }

    public Task<DeleteRoleProfilesResponse> DeleteRoleAsync(
      DeleteRoleProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteRoleAsync(request);
    }

    public Task<GetRolesProfilesResponse> GetRolesAsync(
      GetRolesProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetRolesAsync(request);
    }

    public Task<RegisterSkillProfilesResponse> RegisterSkillAsync(
      RegisterSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterSkillAsync(request);
    }

    public Task<DeleteSkillProfilesResponse> DeleteSkillAsync(
      DeleteSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteSkillAsync(request);
    }

    public Task<GetSkillsProfilesResponse> GetSkillAsync(
      GetSkillsProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetSkillAsync(request);
    }

    public Task<UpdateSkillProfilesResponse> UpdateSkillRoleAsync(
      UpdateSkillProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateSkillRoleAsync(request);
    }

    public Task<DeleteProfessionalProfilesResponse> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.DeleteProfessionalAsync(request);
    }

    public Task<GetProfessionalProfilesResponse> GetProfessionalAsync(
      GetProfessionalsProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.GetProfessionalAsync(request);
    }

    public Task<RegisterProfessionalProfilesResponse> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.RegisterProfessionalAsync(request);
    }

    public Task<UpdateProfessionalProfilesResponse> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      return Client.UpdateProfessionalAsync(request);
    }
  }
}
