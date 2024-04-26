using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class DeleteProvinceHelper : BaseHelperServiceInfrastructure
{
    public static async Task<DeleteProvinceResponse> DeleteProvinceAsync(DeleteProvinceRequest request)
    {
        var deleteProvinceCommand = MapToDeleteProvinceCommand(request);
        var data = await Application.DeleteProvince(deleteProvinceCommand);
        return MapToDeleteProvinceResponse(data);
    }

    private static DeleteProvinceCommand MapToDeleteProvinceCommand(DeleteProvinceRequest request)
    {
        return new DeleteProvinceCommand { ProvinceId = request.ProvinceId };
    }

    private static DeleteProvinceResponse MapToDeleteProvinceResponse(
        DeleteProvinceApplicationResponse data
    )
    {
        return new DeleteProvinceResponse { ProvinceId = data.ProvinceId };
    }
}
