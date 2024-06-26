using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Services;
using Infrastructure.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;

namespace ApiGateway.Infrastructure.Controllers
{
  [ApiController]
  [Route("api/access-control")]
  public class AnalyticsController(AnalyticsService analyticsService, ICacheService cacheService)
    : BaseController(cacheService)
  {
    private readonly AnalyticsService _analyticsService = analyticsService;

    [Permissions]
    [HttpPost("level")]
    public async Task<IActionResult> RegisterLevelAsync(
      [FromBody] RegisterLevelAnalyticsRequest request
    )
    {
      return Handle(Response<object>.Success(await _analyticsService.RegisterLevelAsync(request)));
    }

    [Permissions]
    [HttpPut("level/{id}")]
    public async Task<IActionResult> UpdateLevelAsync(
      string id,
      [FromBody] UpdateLevelAnalyticsRequest request
    )
    {
      request.LevelId = id;
      return Handle(Response<object>.Success(await _analyticsService.UpdateLevelAsync(request)));
    }

    [Permissions]
    [HttpDelete("level/{id}")]
    public async Task<IActionResult> DeleteLevelAsync(string id)
    {
      var request = new DeleteLevelAnalyticsRequest { LevelId = id };
      return Handle(Response<object>.Success(await _analyticsService.DeleteLevelAsync(request)));
    }

    [Permissions]
    [HttpGet("levels")]
    public async Task<IActionResult> GetLevelsAsync([FromQuery] GetLevelsAnalyticsRequest request)
    {
      return Handle(Response<object>.Success(await _analyticsService.GetLevelsAsync(request)));
    }
  }
}
