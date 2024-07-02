using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class DeleteProfessionalHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<DeleteProfessionalProfilesResponse>> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request
    )
    {
      var newUserCommand = MapToDeleteProfessionalCommand(request);
      var response = await Application.DeleteProfessional(newUserCommand);

      if (response.IsFailure)
      {
        return Response<DeleteProfessionalProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteProfessionalProfilesResponse>.Success(
        MapToDeleteProfessionalResponse(response.Data)
      );
    }

    private static DeleteProfessionalProfilesResponse MapToDeleteProfessionalResponse(
      DeleteProfessionalApplicationResponse data
    )
    {
      return new DeleteProfessionalProfilesResponse { ProfessionalId = data.ProfessionalId, };
    }

    private static DeleteProfessionalCommand MapToDeleteProfessionalCommand(
      DeleteProfessionalProfilesRequest request
    )
    {
      return new DeleteProfessionalCommand { ProfessionalId = request.ProfessionalId, };
    }
  }
}
