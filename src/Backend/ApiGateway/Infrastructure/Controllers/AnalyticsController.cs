using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.ProtocolBuffers.Analytics.Requests;

namespace ApiGateway.Infrastructure.Controllers
{
  [ApiController]
  [Route("api/access-control")]
  public class AnalyticsController : BaseController
  {
    private readonly AnalyticsService _analyticsService;

    public AnalyticsController(AnalyticsService analyticsService)
    {
      _analyticsService = analyticsService;
    }

    [HttpPost("level")]
    public async Task<IActionResult> RegisterLevelAsync(
      [FromBody] RegisterLevelAnalyticsRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _analyticsService.RegisterLevelAsync(request)));
    }

    [HttpPut("level/{id}")]
    public async Task<IActionResult> UpdateLevelAsync(
      string id,
      [FromBody] UpdateLevelAnalyticsRequest request
    )
    {
      request.LevelId = id;
      return await HandleAsync(async () => Ok(await _analyticsService.UpdateLevelAsync(request)));
    }

    [HttpDelete("level/{id}")]
    public async Task<IActionResult> DeleteLevelAsync(string id)
    {
      var request = new DeleteLevelAnalyticsRequest { LevelId = id };
      return await HandleAsync(async () => Ok(await _analyticsService.DeleteLevelAsync(request)));
    }

    [HttpGet("levels")]
    public async Task<IActionResult> GetLevelsAsync([FromQuery] GetLevelsAnalyticsRequest request)
    {
      return await HandleAsync(async () => Ok(await _analyticsService.GetLevelsAsync(request)));
    }
  }
}
