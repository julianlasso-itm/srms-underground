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
    private readonly ProfilesService _profilesService;

    public ProfilesController(ProfilesService profilesService)
    {
      _profilesService = profilesService;
    }

    [HttpPost("country")]
    public async Task<IActionResult> RegisterCountryAsync([FromBody] RegisterCountryRequest request)
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterCountryAsync(request))
      );
    }

    [HttpPut("country/{id}")]
    public async Task<IActionResult> UpdateCountryAsync(
      string id,
      [FromBody] UpdateCountryRequest request
    )
    {
      request.CountryId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateCountryAsync(request)));
    }

    [HttpDelete("country/{id}")]
    public async Task<IActionResult> DeleteCountryAsync(string id)
    {
      var request = new DeleteCountryRequest { CountryId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteCountryAsync(request)));
    }

    [HttpGet("countries")]
    public async Task<IActionResult> GetCountryAsync([FromQuery] GetCountriesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetCountriesAsync(request)));
    }

    [HttpPost("province")]
    public async Task<IActionResult> RegisterProvinceAsync(
      [FromBody] RegisterProvinceRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterProvinceAsync(request))
      );
    }

    [HttpPut("province/{id}")]
    public async Task<IActionResult> UpdateProvinceAsync(
      string id,
      [FromBody] UpdateProvinceRequest request
    )
    {
      request.ProvinceId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateProvinceAsync(request)));
    }

    [HttpDelete("province/{id}")]
    public async Task<IActionResult> DeleteProvinceAsync(string id)
    {
      var request = new DeleteProvinceRequest { ProvinceId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteProvinceAsync(request)));
    }

    [HttpGet("provinces")]
    public async Task<IActionResult> GetProvincesAsync([FromQuery] GetProvincesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetProvincesAsync(request)));
    }

    [HttpPost("city")]
    public async Task<IActionResult> RegisterCityAsync([FromBody] RegisterCityRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.RegisterCityAsync(request)));
    }

    [HttpPut("city/{id}")]
    public async Task<IActionResult> UpdateCityAsync(
      string id,
      [FromBody] UpdateCityRequest request
    )
    {
      request.CityId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateCityAsync(request)));
    }

    [HttpDelete("city/{id}")]
    public async Task<IActionResult> DeleteCityAsync(string id)
    {
      var request = new DeleteCityRequest { CityId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteCityAsync(request)));
    }

    [HttpGet("cities")]
    public async Task<IActionResult> GetCitiesAsync([FromQuery] GetCitiesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetCitiesAsync(request)));
    }

    [HttpPost("role")]
    public async Task<IActionResult> RegisterRoleAsync([FromBody] RegisterRoleRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.RegisterRoleAsync(request)));
    }

    [HttpPut("role/{id}")]
    public async Task<IActionResult> UpdateRoleAsync(
      string id,
      [FromBody] UpdateRoleRequest request
    )
    {
      request.RoleId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateRoleAsync(request)));
    }

    [HttpDelete("role/{id}")]
    public async Task<IActionResult> DeleteRoleAsync(string id)
    {
      var request = new DeleteRoleRequest { RoleId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteRoleAsync(request)));
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync([FromQuery] GetRolesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetRolesAsync(request)));
    }

    [HttpPost("skill")]
    public async Task<IActionResult> RegisterSkillAsync([FromBody] RegisterSkillRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.RegisterSkillAsync(request)));
    }

    [HttpPut("skill/{id}")]
    public async Task<IActionResult> UpdateSkillAsync(
      string id,
      [FromBody] UpdateSkillRequest request
    )
    {
      request.SkillId = id;
      return await HandleAsync(
        async () => Ok(await _profilesService.UpdateSkillRoleAsync(request))
      );
    }

    [HttpDelete("skill/{id}")]
    public async Task<IActionResult> DeleteSkillAsync(string id)
    {
      var request = new DeleteSkillRequest { SkillId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteSkillAsync(request)));
    }

    [HttpGet("skills")]
    public async Task<IActionResult> GetSkillsAsync([FromQuery] GetSkillsRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetSkillAsync(request)));
    }

    [HttpPost("professional")]
    public async Task<IActionResult> RegisterProfessionalAsync(
      [FromBody] RegisterProfessionalRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterProfessionalAsync(request))
      );
    }

    [HttpPut("professional/{id}")]
    public async Task<IActionResult> UpdateProfessionalAsync(
      string id,
      [FromBody] UpdateProfessionalRequest request
    )
    {
      request.ProfessionalId = id;
      return await HandleAsync(
        async () => Ok(await _profilesService.UpdateProfessionalAsync(request))
      );
    }

    [HttpDelete("professional/{id}")]
    public async Task<IActionResult> DeleteProfessionalAsync(string id)
    {
      var request = new DeleteProfessionalRequest { ProfessionalId = id };
      return await HandleAsync(
        async () => Ok(await _profilesService.DeleteProfessionalAsync(request))
      );
    }

    [HttpGet("professionals")]
    public async Task<IActionResult> GetProfessionalsAsync(
      [FromQuery] GetProfessionalsRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.GetProfessionalAsync(request))
      );
    }
  }
}
