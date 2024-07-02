using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.Helpers
{
  internal class UpdateLevelHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateLevelAnalyticsResponse>> UpdateLevelAsync(
      UpdateLevelAnalyticsRequest request
    )
    {
      var updateLevelCommand = MapToUpdateLevelCommand(request);
      var data = await Application.UpdateLevel(updateLevelCommand);

      if (data.IsFailure)
      {
        return Response<UpdateLevelAnalyticsResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<UpdateLevelAnalyticsResponse>.Success(MapToUpdateLevelResponse(data.Data));
    }

    private static UpdateLevelCommand MapToUpdateLevelCommand(UpdateLevelAnalyticsRequest request)
    {
      return new UpdateLevelCommand
      {
        LevelId = request.LevelId!,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable
      };
    }

    private static UpdateLevelAnalyticsResponse MapToUpdateLevelResponse(
      UpdateLevelApplicationResponse data
    )
    {
      return new UpdateLevelAnalyticsResponse
      {
        LevelId = data.LevelId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
      };
    }
  }
}
