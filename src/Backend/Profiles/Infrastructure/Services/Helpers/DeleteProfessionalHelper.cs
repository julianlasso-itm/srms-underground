using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
    public class DeleteProfessionalHelper : BaseHelperServiceInfrastructure
    {
        public static async Task<DeleteProfessionalResponse> DeleteProfessionalAsync(
            DeleteProfessionalRequest request
        )
        {
            var newUserCommand = MapToDeleteProfessionalCommand(request);
            var data = await Application.DeleteProfessional(newUserCommand);
            return MapToDeleteProfessionalResponse(data);
        }

        private static DeleteProfessionalResponse MapToDeleteProfessionalResponse(
            DeleteProfessionalApplicationResponse data
        )
        {
            return new DeleteProfessionalResponse { ProfessionalId = data.ProfessionalId, };
        }

        private static DeleteProfessionalCommand MapToDeleteProfessionalCommand(
            DeleteProfessionalRequest request
        )
        {
            return new DeleteProfessionalCommand { ProfessionalId = request.ProfessionalId, };
        }
    }
}
