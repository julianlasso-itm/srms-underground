﻿using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
    public class UpdateProfessionalHelper : BaseHelperServiceInfrastructure
    {
        public static async Task<UpdateProfessionalResponse> UpdateProfessionalAsync(
            UpdateProfessionalRequest request
        )
        {
            var newUserCommand = MapToUpdateProfessionalCommand(request);
            var data = await Application.UpdateProfessional(newUserCommand);
            return MapToUpdateProfessionalResponse(data);
        }

        private static UpdateProfessionalCommand MapToUpdateProfessionalCommand(
            UpdateProfessionalRequest request
        )
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
