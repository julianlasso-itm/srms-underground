using Profiles.Application;
using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class UpdateProfessionalHelper
    {
        private static Application<Country, State, City, Skill, Professional> s_application;

        public static void SetApplication(Application<Country, State, City, Skill, Professional> application)
        {
            s_application = application;
        }

        public static async Task<UpdateProfessionalResponse> UpdateProfessionalAsync(UpdateProfessionalRequest request)
        {
            var newUserCommand = MapToUpdateProfessionalCommand(request);
            var data = await s_application.UpdateProfessional(newUserCommand);
            return MapToUpdateProfessionalResponse(data);
        }

        private static UpdateProfessionalCommand MapToUpdateProfessionalCommand(UpdateProfessionalRequest request)
        {
            return new UpdateProfessionalCommand
            {
                ProfessionalId = request.ProfessionalId!,
                Name = request.Name,
                Email = request.Email,
                Disabled = request.Disable
            };
        }

        private static UpdateProfessionalResponse MapToUpdateProfessionalResponse(
            UpdateProfessionalApplicationResponse data
        )
        {
            return new UpdateProfessionalResponse
            {
                ProfessionalId = data.ProfessionalId!,
                Name = data.Name,
                Email = data.Email,
                Disabled = data.Disabled
            };
        }

    }
}
