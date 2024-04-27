using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;

namespace ApiGateway.Infrastructure.Controllers
{

    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController: BaseController
    {

        private readonly ProfilesService _profilesServices;

        public ProfilesController(ProfilesService profilesService)
        {
            _profilesServices = profilesService;
        }

        [HttpPost("skill")]
        public async Task<IActionResult> RegisterSkillAsync([FromBody] RegisterSkillRequest request)
        {
            return await HandleAsync(
                async () => Ok(await _profilesServices.RegisterSkillAsync(request))
            );
        }


        [HttpPut("skill/{id}")]
        public async Task<IActionResult> UpdateSkillAsync(
            string id,
            [FromBody] UpdateSkillRequest request
        )
        {
            request.SkillId = id;
            return await HandleAsync(
                async () => Ok(await _profilesServices.UpdateSkillRoleAsync(request))
            );
        }

        [HttpDelete("skill/{id}")]
        public async Task<IActionResult> DeleteRoleAsync(string id)
        {
            var request = new DeleteSkillRequest { SkillId = id };
            return await HandleAsync(
                async () => Ok(await _profilesServices.DeleteSkillAsync(request))
            );
        }

        [HttpGet("skills")]
        public async Task<IActionResult> GetSkillsAsync([FromQuery] GetSkillsRequest request)
        {
            return await HandleAsync(
                async () => Ok(await _profilesServices.GetSkillAsync(request))
            );
        }


        [HttpPost("professional")]
        public async Task<IActionResult> RegisterProfessionalAsync([FromBody] RegisterProfessionalRequest request)
        {
            return await HandleAsync(
                async () => Ok(await _profilesServices.RegisterProfessionalAsync(request))
            );
        }


        [HttpPut("professional/{id}")]
        public async Task<IActionResult> UpdateProfessionalAsync(
            string id,
            [FromBody] UpdateProfessionalRequest request
        )
        {
            request.ProfessionalId = id;
            return await HandleAsync(
                async () => Ok(await _profilesServices.UpdateProfessionalAsync(request))
            );
        }

        [HttpDelete("professional/{id}")]
        public async Task<IActionResult> DeleteProfessionalAsync(string id)
        {
            var request = new DeleteProfessionalRequest { ProfessionalId = id };
            return await HandleAsync(
                async () => Ok(await _profilesServices.DeleteProfessionalAsync(request))
            );
        }

        [HttpGet("professionals")]
        public async Task<IActionResult> GetProfessionalsAsync([FromQuery] GetProfessionalsRequest request)
        {
            return await HandleAsync(
                async () => Ok(await _profilesServices.GetProfessionalAsync(request))
            );
        }
    }
}
