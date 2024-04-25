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


        [HttpPut("role/{id}")]
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

        [HttpDelete("role/{id}")]
        public async Task<IActionResult> DeleteRoleAsync(string id)
        {
            var request = new DeleteSkillRequest { SkillId = id };
            return await HandleAsync(
                async () => Ok(await _profilesServices.DeleteSkillAsync(request))
            );
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetSkillsAsync([FromQuery] GetSkillsRequest request)
        {
            return await HandleAsync(
                async () => Ok(await _profilesServices.GetSkillAsync(request))
            );
        }

    }
}
