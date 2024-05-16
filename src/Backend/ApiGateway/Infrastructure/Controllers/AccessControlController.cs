using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Dto;
using ApiGateway.Infrastructure.Services;
using Infrastructure.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Interfaces;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace ApiGateway.Infrastructure.Controllers
{
  [ApiController]
  [Route("api/access-control")]
  public class AccessControlController : BaseController
  {
    private readonly AccessControlService _accessControlService;

    public AccessControlController(
      AccessControlService accessControlService,
      ICacheService cacheService
    )
      : base(cacheService)
    {
      _accessControlService = accessControlService;
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> RegisterUserAsync([FromForm] RegisterUserRequestDto request)
    {
      using var memoryStream = new MemoryStream();
      await request.Avatar.CopyToAsync(memoryStream);
      var avatar = memoryStream.ToArray();
      var id = Guid.NewGuid().ToString();
      CacheService.Set(id, avatar);

      var newRequest = new RegisterUserRequest
      {
        Name = request.Name,
        Email = request.Email,
        Password = request.Password,
        Avatar = id,
        AvatarExtension = Path.GetExtension(request.Avatar.FileName),
      };

      return await HandleAsync(
        async () => Ok(await _accessControlService.RegisterUserAsync(newRequest))
      );
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync([FromBody] SignInAccessControlRequest request)
    {
      return await HandleAsync(async () => Ok(await _accessControlService.SignInAsync(request)));
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

    [Permissions("User")]
    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync([FromQuery] GetRolesAccessControlRequest request)
    {
      return await HandleAsync(async () => Ok(await _accessControlService.GetRolesAsync(request)));
    }

    [HttpGet("activate-token/{activationToken}")]
    public async Task<IActionResult> ActivateTokenAsync(string activationToken)
    {
      var request = new ActivationTokenAccessControlRequest { ActivationToken = activationToken };
      return await HandleAsync(
        async () => Ok(await _accessControlService.ActivateTokenAsync(request))
      );
    }
  }
}
