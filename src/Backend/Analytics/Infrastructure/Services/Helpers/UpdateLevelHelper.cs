using Analytics.Application.Commands;
using Analytics.Application.Responses;
using Analytics.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Responses;

namespace Analytics.Infrastructure.Services.Helpers;

internal class UpdateLevelHelper : BaseHelperServiceInfrastructure
{
    public static async Task<UpdateLevelSecurityResponse> UpdateLevelAsync(
        UpdateLevelSecurityRequest request
    )
    {
        var updateLevelCommand = MapToUpdateLevelCommand(request);
        var data = await Application.UpdateLevel(updateLevelCommand);
        return MapToUpdateLevelResponse(data);
    }

    private static UpdateLevelCommand MapToUpdateLevelCommand(UpdateLevelSecurityRequest request)
    {
        return new UpdateLevelCommand
        {
            LevelId = request.LevelId!,
            Name = request.Name,
            Description = request.Description,
            Disable = request.Disable
        };
    }

    private static UpdateLevelSecurityResponse MapToUpdateLevelResponse(
        UpdateLevelApplicationResponse data
    )
    {
        return new UpdateLevelSecurityResponse
        {
            LevelId = data.LevelId,
            Name = data.Name,
            Description = data.Description,
            Disabled = data.Disabled,
        };
    }
}
