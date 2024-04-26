using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class DeleteCountryHelper : BaseHelperServiceInfrastructure
{
    public static async Task<DeleteCountryResponse> DeleteCountryAsync(DeleteCountryRequest request)
    {
        var deleteCountryCommand = MapToDeleteCountryCommand(request);
        var data = await Application.DeleteCountry(deleteCountryCommand);
        return MapToDeleteCountryResponse(data);
    }

    private static DeleteCountryCommand MapToDeleteCountryCommand(DeleteCountryRequest request)
    {
        return new DeleteCountryCommand { CountryId = request.CountryId };
    }

    private static DeleteCountryResponse MapToDeleteCountryResponse(
        DeleteCountryApplicationResponse data
    )
    {
        return new DeleteCountryResponse { CountryId = data.CountryId };
    }
}
