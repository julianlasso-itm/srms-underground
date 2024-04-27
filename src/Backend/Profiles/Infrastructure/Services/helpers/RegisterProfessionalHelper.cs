// Licensed to the .NET Foundation under one or more agreements.

using Profiles.Application;
using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class RegisterProfessionalHelper
    {
        private static Application<Country, State, City, Skill, Professional> s_application;

        public static void SetApplication(Application<Country, State, City, Skill, Professional> application)
        {
            s_application = application;
        }

        public static async Task<RegisterProfessionalResponse> RegisterProfessionalAsync(RegisterProfessionalRequest request)
        {
            var newUserCommand = MapToNewUserCommand(request);
            var data = await s_application.RegisterProfessional(newUserCommand);
            return MapToRegisterProfessionalResponse(data);
        }

        private static RegisterProfessionalCommand MapToNewUserCommand(RegisterProfessionalRequest request)
        {
            return new RegisterProfessionalCommand
            {
                Name = request.Name,
                Email = request.Email,   
                Disabled = request.Disabled
            };
        }

        private static RegisterProfessionalResponse MapToRegisterProfessionalResponse(
            RegisterProfessionalApplicationResponse data
        )
        {
            return new RegisterProfessionalResponse
            {
                Name = data.Name,
                Email = data.Email,
                Disabled = data.Disabled
            };
        }
    }
}
