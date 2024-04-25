using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace ApiGateway.Infrastructure.Controllers;

[ApiController]
[Route("api/access-control")]
public class AccessControlController : BaseController
{
    private readonly AccessControlService _accessControlService;

    public AccessControlController(AccessControlService accessControlService)
    {
        _accessControlService = accessControlService;
    }

    [HttpPost("role")]
    public async Task<IActionResult> RegisterRoleAsync([FromBody] RegisterRoleRequest request)
    {
        return await HandleAsync(
            async () => Ok(await _accessControlService.RegisterRoleAsync(request))
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
            async () => Ok(await _accessControlService.UpdateRoleAsync(request))
        );
    }

    [HttpDelete("role/{id}")]
    public async Task<IActionResult> DeleteRoleAsync(string id)
    {
        var request = new DeleteRoleRequest { RoleId = id };
        return await HandleAsync(
            async () => Ok(await _accessControlService.DeleteRoleAsync(request))
        );
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync([FromQuery] GetRolesRequest request)
    {
        return await HandleAsync(
            async () => Ok(await _accessControlService.GetRolesAsync(request))
        );
    }
}
