using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.Helpers
{
  internal class DeleteLevelHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteLevelAnalyticsResponse> DeleteLevelAsync(
      DeleteLevelAnalyticsRequest request
    )
    {
      var deleteLevelCommand = MapToDeleteLevelCommand(request);
      var data = await Application.DeleteLevel(deleteLevelCommand);
      return MapToDeleteLevelResponse(data);
    }

    private static DeleteLevelCommand MapToDeleteLevelCommand(DeleteLevelAnalyticsRequest request)
    {
      return new DeleteLevelCommand { LevelId = request.LevelId };
    }

    private static DeleteLevelAnalyticsResponse MapToDeleteLevelResponse(
      DeleteLevelApplicationResponse data
    )
    {
      return new DeleteLevelAnalyticsResponse { LevelId = data.LevelId };
    }
  }
}
