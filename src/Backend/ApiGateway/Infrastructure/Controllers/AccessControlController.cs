using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace ApiGateway.Infrastructure.Controllers
{
  [ApiController]
  [Route("api/access-control")]
  public class AccessControlController : BaseController
  {
    private readonly AccessControlService _accessControlService;

    public AccessControlController(AccessControlService accessControlService)
    {
      _accessControlService = accessControlService;
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> RegisterUserAsync(
      [FromBody] RegisterUserRequest request,
      [FromForm] IFormFile file
    )
    {
      return await HandleAsync(
        async () => Ok(await _accessControlService.RegisterUserAsync(request))
      );
    }

    [HttpPost("role")]
    public async Task<IActionResult> RegisterRoleAsync(
      [FromBody] RegisterRoleAccessControlRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _accessControlService.RegisterRoleAsync(request))
      );
    }

    [HttpPut("role/{id}")]
    public async Task<IActionResult> UpdateRoleAsync(
      string id,
      [FromBody] UpdateRoleAccessControlRequest request
    )
    {
      request.RoleId = id;
      return await HandleAsync(
        async () => Ok(await _accessControlService.UpdateRoleAsync(request))
      );
    }

    [HttpDelete("role/{id}")]
    public async Task<IActionResult> DeleteRoleAsync(string id)
    {
      var request = new DeleteRoleAccessControlRequest { RoleId = id };
      return await HandleAsync(
        async () => Ok(await _accessControlService.DeleteRoleAsync(request))
      );
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync([FromQuery] GetRolesAccessControlRequest request)
    {
      return await HandleAsync(async () => Ok(await _accessControlService.GetRolesAsync(request)));
    }
  }
}
