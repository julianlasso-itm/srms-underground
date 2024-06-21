using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.Helpers
{
  internal class RegisterLevelHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterLevelAnalyticsResponse>> RegisterLevelAsync(
      RegisterLevelAnalyticsRequest request
    )
    {
      var newLevelCommand = MapToRegisterLevelCommand(request);
      var data = await Application.RegisterLevel(newLevelCommand);

      if (data.IsFailure)
      {
        return Response<RegisterLevelAnalyticsResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<RegisterLevelAnalyticsResponse>.Success(
        MapToRegisterLevelResponse(data.Data)
      );
    }

    private static RegisterLevelCommand MapToRegisterLevelCommand(
      RegisterLevelAnalyticsRequest request
    )
    {
      return new RegisterLevelCommand { Name = request.Name, Description = request.Description, };
    }

    private static RegisterLevelAnalyticsResponse MapToRegisterLevelResponse(
      RegisterLevelApplicationResponse data
    )
    {
      return new RegisterLevelAnalyticsResponse
      {
        LevelId = data.LevelId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
      };
    }
  }
}
