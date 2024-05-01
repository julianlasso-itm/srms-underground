using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class DeleteProfessionalHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteProfessionalProfilesResponse> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request
    )
    {
      var newUserCommand = MapToDeleteProfessionalCommand(request);
      var data = await Application.DeleteProfessional(newUserCommand);
      return MapToDeleteProfessionalResponse(data);
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
