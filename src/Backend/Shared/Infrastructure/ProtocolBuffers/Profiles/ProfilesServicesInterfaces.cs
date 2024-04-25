using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles;

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
}
