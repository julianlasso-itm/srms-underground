using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Dto;
using ApiGateway.Infrastructure.Services;
using Grpc.Core;
using Infrastructure.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace ApiGateway.Infrastructure.Controllers
{
  [ApiController]
  [Route("api/access-control")]
  public class AccessControlController(
    AccessControlService accessControlService,
    ICacheService cacheService
  ) : BaseController(cacheService)
  {
    private readonly AccessControlService _accessControlService = accessControlService;

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

      return Handle(
        Response<object>.Success(await _accessControlService.RegisterUserAsync(newRequest))
      );
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignInAsync([FromBody] SignInAccessControlRequest request)
    {
      return Handle(Response<object>.Success(await _accessControlService.SignInAsync(request)));
    }

    [Permissions]
    [HttpPost("role")]
    public async Task<IActionResult> RegisterRoleAsync(
      [FromBody] RegisterRoleAccessControlRequest request
    )
    {
      return Handle(
        Response<object>.Success(await _accessControlService.RegisterRoleAsync(request))
      );
    }

    [Permissions]
    [HttpPut("role/{id}")]
    public async Task<IActionResult> UpdateRoleAsync(
      string id,
      [FromBody] UpdateRoleAccessControlRequest request
    )
    {
      request.RoleId = id;
      return Handle(Response<object>.Success(await _accessControlService.UpdateRoleAsync(request)));
    }

    [Permissions]
    [HttpDelete("role/{id}")]
    public async Task<IActionResult> DeleteRoleAsync(string id)
    {
      var request = new DeleteRoleAccessControlRequest { RoleId = id };
      return Handle(Response<object>.Success(await _accessControlService.DeleteRoleAsync(request)));
    }

    [Permissions]
    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync([FromQuery] GetRolesAccessControlRequest request)
    {
      return Handle(Response<object>.Success(await _accessControlService.GetRolesAsync(request)));
    }

    [HttpGet("activate-account/{activationToken}")]
    public async Task<IActionResult> ActivateTokenAsync(string activationToken)
    {
      var request = new ActivationTokenAccessControlRequest { ActivationToken = activationToken };
      return Handle(
        Response<object>.Success(await _accessControlService.ActivateTokenAsync(request))
      );
    }

    [Permissions]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(
      [FromBody] ChangePasswordAccessControlRequest request
    )
    {
      request.UserId = HttpContext.Items["UserId"]?.ToString();
      return Handle(
        Response<object>.Success(await _accessControlService.ChangePasswordAsync(request))
      );
    }

    [HttpPost("password-recovery")]
    public async Task<IActionResult> PasswordRecoveryAsync(
      [FromBody] PasswordRecoveryAccessControlRequest request
    )
    {
      return Handle(
        Response<object>.Success(await _accessControlService.PasswordRecoveryAsync(request))
      );
    }

    [Permissions]
    [HttpPut("update-user")]
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

      if (request.CityId is not null)
      {
        newRequest.CityId = request.CityId;
      }

      return Handle(
        Response<object>.Success(await _accessControlService.UpdateUserAsync(newRequest))
      );
    }

    [HttpPost("verify-token")]
    public async Task<IActionResult> VerifyTokenAsync([FromBody] VerifyTokeDto request)
    {
      var data = new VerifyTokenAccessControlRequest { Token = request.Token };
      return Handle(Response<object>.Success(await _accessControlService.VerifyTokenAsync(data)));
      // await _accessControlService.VerifyTokenAsync(
      //   new VerifyTokenAccessControlRequest { Token = request.Token }
      // );
      // return Ok(new { message = "Token is valid" });
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPasswordAsync(
      [FromBody] ResetPasswordAccessControlRequest request
    )
    {
      return Handle(
        Response<object>.Success(await _accessControlService.ResetPasswordAsync(request))
      );
      // return await HandleAsync(
      //   async () => Ok(await _accessControlService.ResetPasswordAsync(request))
      // );
    }
  }
}
