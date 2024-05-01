using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class DeleteProvinceHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteProvinceProfilesResponse> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request
    )
    {
      var deleteProvinceCommand = MapToDeleteProvinceCommand(request);
      var data = await Application.DeleteProvince(deleteProvinceCommand);
      return MapToDeleteProvinceResponse(data);
    }

    private static DeleteProvinceCommand MapToDeleteProvinceCommand(
      DeleteProvinceProfilesRequest request
    )
    {
      return new DeleteProvinceCommand { ProvinceId = request.ProvinceId };
    }

    private static DeleteProvinceProfilesResponse MapToDeleteProvinceResponse(
      DeleteProvinceApplicationResponse data
    )
    {
      return new DeleteProvinceProfilesResponse { ProvinceId = data.ProvinceId };
    }
  }
}
