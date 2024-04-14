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

    [HttpPost("user/register")]
    public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequest request)
    {
        return await HandleAsync(
            async () => Ok(await _accessControlService.RegisterUserAsync(request))
        );
    }

    [HttpPost("role/register")]
    public async Task<IActionResult> RegisterRoleAsync([FromBody] RegisterRoleRequest request)
    {
        return await HandleAsync(
            async () => Ok(await _accessControlService.RegisterRoleAsync(request))
        );
    }

    [HttpPost("role/update")]
    public async Task<IActionResult> UpdateRoleAsync([FromBody] UpdateRoleRequest request)
    {
        return await HandleAsync(
            async () => Ok(await _accessControlService.UpdateRoleAsync(request))
        );
    }

    [HttpPost("role/delete")]
    public async Task<IActionResult> DeleteRoleAsync([FromBody] DeleteRoleRequest request)
    {
        return await HandleAsync(
            async () => Ok(await _accessControlService.DeleteRoleAsync(request))
        );
    }
}
