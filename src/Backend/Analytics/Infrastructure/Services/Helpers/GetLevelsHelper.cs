using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Persistence.Models;
using Analytics.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.Helpers
{
  internal class GetLevelsHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<GetLevelsAnalyticsResponse>> GetLevelsAsync(
      GetLevelsAnalyticsRequest request
    )
    {
      var getLevelsCommand = MapToGetLevelsCommand(request);
      var data = await Application.GetLevels(getLevelsCommand);

      if (data.IsFailure)
      {
        return Response<GetLevelsAnalyticsResponse>.Failure(data.Message, data.Code, data.Details);
      }

      return Response<GetLevelsAnalyticsResponse>.Success(MapToGetLevelsResponse(data.Data));
    }

    private static GetLevelsCommand MapToGetLevelsCommand(GetLevelsAnalyticsRequest request)
    {
      return new GetLevelsCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        FilterBy = request.FilterBy,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    private static GetLevelsAnalyticsResponse MapToGetLevelsResponse(
      GetLevelsApplicationResponse<LevelModel> data
    )
    {
      return new GetLevelsAnalyticsResponse
      {
        Levels = data
          .Levels.Select(level => new LevelAnalytics
          {
            LevelId = level.LevelId.ToString(),
            Name = level.Name,
            Description = level.Description,
            Disabled = level.Disabled
          })
          .ToList(),
        Total = data.Total
      };
    }
  }
}
