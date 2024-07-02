using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class DeleteProvinceHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<DeleteProvinceProfilesResponse>> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request
    )
    {
      var deleteProvinceCommand = MapToDeleteProvinceCommand(request);
      var response = await Application.DeleteProvince(deleteProvinceCommand);

      if (response.IsFailure)
      {
        return Response<DeleteProvinceProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteProvinceProfilesResponse>.Success(
        MapToDeleteProvinceResponse(response.Data)
      );
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
