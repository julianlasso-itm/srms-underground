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
      var idAvatar = Guid.NewGuid().ToString();
      CacheService.Set(idAvatar, avatar);

      var newRequest = new RegisterUserRequest
      {
        Name = request.Name,
        Email = request.Email,
        Password = request.Password,
        CityId = request.CityId,
        Avatar = idAvatar,
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

    [HttpGet("activate-account/{activationToken}")]
    public async Task<IActionResult> ActivateTokenAsync(string activationToken)
    {
      var request = new ActivationTokenAccessControlRequest { ActivationToken = activationToken };
      return await HandleAsync(
        async () => Ok(await _accessControlService.ActivateTokenAsync(request))
      );
    }

    [Permissions]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(
      [FromBody] ChangePasswordAccessControlRequest request
    )
    {
      request.UserId = HttpContext.Items["UserId"]?.ToString();
      return await HandleAsync(
        async () => Ok(await _accessControlService.ChangePasswordAsync(request))
      );
    }

    [HttpPost("password-recovery")]
    public async Task<IActionResult> PasswordRecoveryAsync(
      [FromBody] PasswordRecoveryAccessControlRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _accessControlService.PasswordRecoveryAsync(request))
      );
    }

    [Permissions]
    [HttpPost("update-user")]
    public async Task<IActionResult> UpdateUserAsync([FromForm] UpdateUserRequestDto request)
    {
      var idAvatar = Guid.NewGuid().ToString();

      if (request.Avatar is not null)
      {
        using var memoryStream = new MemoryStream();
        await request.Avatar.CopyToAsync(memoryStream);
        var avatar = memoryStream.ToArray();
        CacheService.Set(idAvatar, avatar);
      }

      var newRequest = new UpdateUserAccessControlRequest
      {
        UserId = HttpContext.Items["UserId"]?.ToString()!
      };

      if (request.Name is not null)
      {
        newRequest.Name = request.Name;
      }

      if (request.Avatar is not null)
      {
        newRequest.Avatar = idAvatar;
        newRequest.AvatarExtension = Path.GetExtension(request.Avatar.FileName);
        newRequest.OldPhoto = HttpContext.Items["Photo"]?.ToString();
      }

      if (request.Disabled is not null)
      {
        newRequest.Disabled = request.Disabled;
      }

      return await HandleAsync(
        async () => Ok(await _accessControlService.UpdateUserAsync(newRequest))
      );
    }

    [HttpPost("verify-token")]
    public async Task<IActionResult> VerifyTokenAsync([FromBody] VerifyTokeDto request)
    {
      await _accessControlService.VerifyTokenAsync(
        new VerifyTokenAccessControlRequest { Token = request.Token }
      );
      return Ok(new { message = "Token is valid" });
    }
  }
}
