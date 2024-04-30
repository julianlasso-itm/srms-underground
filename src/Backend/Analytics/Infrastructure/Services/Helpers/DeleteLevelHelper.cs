using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.Helpers
{
  internal class DeleteLevelHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteLevelSecurityResponse> DeleteLevelAsync(
      DeleteLevelSecurityRequest request
    )
    {
      var deleteLevelCommand = MapToDeleteLevelCommand(request);
      var data = await Application.DeleteLevel(deleteLevelCommand);
      return MapToDeleteLevelResponse(data);
    }

    private static DeleteLevelCommand MapToDeleteLevelCommand(DeleteLevelSecurityRequest request)
    {
      return new DeleteLevelCommand { LevelId = request.LevelId };
    }

    private static DeleteLevelSecurityResponse MapToDeleteLevelResponse(
      DeleteLevelApplicationResponse data
    )
    {
      return new DeleteLevelSecurityResponse { LevelId = data.LevelId };
    }
  }
}
