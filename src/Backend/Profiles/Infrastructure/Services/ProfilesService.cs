using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services;

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
        throw new NotImplementedException();
    }

    public Task<DeleteCountryResponse> DeleteCountryAsync(
        DeleteCountryRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<DeleteProvinceResponse> DeleteProvinceAsync(
        DeleteProvinceRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<GetCitiesResponse> GetCitiesAsync(
        GetCitiesRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<GetCountriesResponse> GetCountriesAsync(
        GetCountriesRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<GetProvincesResponse> GetProvincesAsync(
        GetProvincesRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<RegisterCityResponse> RegisterCityAsync(
        RegisterCityRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<RegisterCountryResponse> RegisterCountryAsync(
        RegisterCountryRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<RegisterProvinceResponse> RegisterProvinceAsync(
        RegisterProvinceRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<UpdateCityResponse> UpdateCityAsync(
        UpdateCityRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<UpdateCountryResponse> UpdateCountryAsync(
        UpdateCountryRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }

    public Task<UpdateProvinceResponse> UpdateProvinceAsync(
        UpdateProvinceRequest request,
        CallContext context = default
    )
    {
        throw new NotImplementedException();
    }
}
