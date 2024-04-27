using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;

namespace ApiGateway.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class ProfilesController : BaseController
    {
        private readonly ProfilesService _profilesServices;

        public ProfilesController(ProfilesService profilesService)
        {
            _profilesServices = profilesService;
        }

        [HttpPost("role")]
        public async Task<IActionResult> RegisterRoleAsync([FromBody] RegisterRoleRequest request)
        {
            return await HandleAsync(
                async () => Ok(await _profilesServices.RegisterRoleAsync(request))
            );
        }

        [HttpPut("role/{id}")]
        public async Task<IActionResult> UpdateRoleAsync(
            string id,
            [FromBody] UpdateRoleRequest request
        )
        {
            request.RoleId = id;
            return await HandleAsync(
                async () => Ok(await _profilesServices.UpdateRoleAsync(request))
            );
        }

        [HttpDelete("role/{id}")]
        public async Task<IActionResult> DeleteRoleAsync(string id)
        {
            var request = new DeleteRoleRequest { RoleId = id };
            return await HandleAsync(
                async () => Ok(await _profilesServices.DeleteRoleAsync(request))
            );
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRolesAsync([FromQuery] GetRolesRequest request)
        {
            return await HandleAsync(
                async () => Ok(await _profilesServices.GetRolesAsync(request))
            );
        }
    }
}
