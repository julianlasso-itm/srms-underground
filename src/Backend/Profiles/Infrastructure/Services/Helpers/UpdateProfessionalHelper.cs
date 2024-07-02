using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class UpdateProfessionalHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateProfessionalProfilesResponse>> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request
    )
    {
      var newUserCommand = MapToUpdateProfessionalCommand(request);
      var response = await Application.UpdateProfessional(newUserCommand);

      if (response.IsFailure)
      {
        return Response<UpdateProfessionalProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<UpdateProfessionalProfilesResponse>.Success(
        MapToUpdateProfessionalResponse(response.Data)
      );
    }

    private static UpdateProfessionalCommand MapToUpdateProfessionalCommand(
      UpdateProfessionalProfilesRequest request
    )
    {
      return new UpdateProfessionalCommand
      {
        ProfessionalId = request.ProfessionalId!,
        Name = request.Name,
        Email = request.Email,
        Disable = request.Disable
      };
    }

    private static UpdateProfessionalProfilesResponse MapToUpdateProfessionalResponse(
      UpdateProfessionalApplicationResponse data
    )
    {
      return new UpdateProfessionalProfilesResponse
      {
        ProfessionalId = data.ProfessionalId!,
        Name = data.Name,
        Email = data.Email,
        Disabled = data.Disabled
      };
    }
  }
}
