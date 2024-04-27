using Profiles.Application;
using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class DeleteProfessionalHelper
    {
        private static Application<Country, State, City, Skill, Professional> s_application;

        internal static void SetApplication(Application<Country, State, City, Skill, Professional> application)
        {
            s_application = application;
        }

        public static async Task<DeleteProfessionalResponse> DeleteProfessionalAsync(DeleteProfessionalRequest request)
        {
            var newUserCommand = MapToDeleteProfessionalCommand(request);
            var data = await s_application.DeleteProfessional(newUserCommand);
            return MapToDeleteProfessionalResponse(data);
        }

        private static DeleteProfessionalResponse MapToDeleteProfessionalResponse(DeleteProfessionalApplicationResponse data)
        {
            return new DeleteProfessionalResponse
            {
                ProfessionalId = data.ProfessionalId,
            };
        }

        private static DeleteProfessionalCommand MapToDeleteProfessionalCommand(DeleteProfessionalRequest request)
        {
            return new DeleteProfessionalCommand
            {
                ProfessionalId = request.ProfessionalId,
            };
        }
    }
}
