using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.Helpers
{
  internal class RegisterLevelHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<RegisterLevelAnalyticsResponse> RegisterLevelAsync(
      RegisterLevelAnalyticsRequest request
    )
    {
      var newLevelCommand = MapToRegisterLevelCommand(request);
      var data = await Application.RegisterLevel(newLevelCommand);
      return MapToRegisterLevelResponse(data);
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
