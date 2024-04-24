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
    }
}
