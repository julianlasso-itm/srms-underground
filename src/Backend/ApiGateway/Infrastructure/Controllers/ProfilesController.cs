using ApiGateway.Infrastructure.Controllers.Base;
using ApiGateway.Infrastructure.Services;
using Infrastructure.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Interfaces;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;

namespace ApiGateway.Infrastructure.Controllers
{
  [ApiController]
  [Route("api/profiles")]
  public class ProfilesController(ProfilesService profilesService, ICacheService cache)
    : BaseController(cache)
  {
    private readonly ProfilesService _profilesService = profilesService;

    [HttpPost("country")]
    public async Task<IActionResult> RegisterCountryAsync(
      [FromBody] RegisterCountryProfilesRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterCountryAsync(request))
      );
    }

    [HttpPut("country/{id}")]
    public async Task<IActionResult> UpdateCountryAsync(
      string id,
      [FromBody] UpdateCountryProfilesRequest request
    )
    {
      request.CountryId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateCountryAsync(request)));
    }

    [HttpDelete("country/{id}")]
    public async Task<IActionResult> DeleteCountryAsync(string id)
    {
      var request = new DeleteCountryProfilesRequest { CountryId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteCountryAsync(request)));
    }

    [HttpGet("countries")]
    public async Task<IActionResult> GetCountryAsync(
      [FromQuery] GetCountriesProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetCountriesAsync(request)));
    }

    [HttpPost("province")]
    public async Task<IActionResult> RegisterProvinceAsync(
      [FromBody] RegisterProvinceProfilesRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterProvinceAsync(request))
      );
    }

    [HttpPut("province/{id}")]
    public async Task<IActionResult> UpdateProvinceAsync(
      string id,
      [FromBody] UpdateProvinceProfilesRequest request
    )
    {
      request.ProvinceId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateProvinceAsync(request)));
    }

    [HttpDelete("province/{id}")]
    public async Task<IActionResult> DeleteProvinceAsync(string id)
    {
      var request = new DeleteProvinceProfilesRequest { ProvinceId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteProvinceAsync(request)));
    }

    [HttpGet("provinces")]
    public async Task<IActionResult> GetProvincesAsync(
      [FromQuery] GetProvincesProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetProvincesAsync(request)));
    }

    [HttpPost("city")]
    public async Task<IActionResult> RegisterCityAsync(
      [FromBody] RegisterCityProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.RegisterCityAsync(request)));
    }

    [HttpPut("city/{id}")]
    public async Task<IActionResult> UpdateCityAsync(
      string id,
      [FromBody] UpdateCityProfilesRequest request
    )
    {
      request.CityId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateCityAsync(request)));
    }

    [HttpDelete("city/{id}")]
    public async Task<IActionResult> DeleteCityAsync(string id)
    {
      var request = new DeleteCityProfilesRequest { CityId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteCityAsync(request)));
    }

    [HttpGet("cities")]
    public async Task<IActionResult> GetCitiesAsync([FromQuery] GetCitiesProfilesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetCitiesAsync(request)));
    }

    [Permissions]
    [HttpPost("role")]
    public async Task<IActionResult> RegisterRoleAsync(
      [FromBody] RegisterRoleProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.RegisterRoleAsync(request)));
    }

    [Permissions]
    [HttpPut("role/{id}")]
    public async Task<IActionResult> UpdateRoleAsync(
      string id,
      [FromBody] UpdateRoleProfilesRequest request
    )
    {
      request.RoleId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateRoleAsync(request)));
    }

    [Permissions]
    [HttpDelete("role/{id}")]
    public async Task<IActionResult> DeleteRoleAsync(string id)
    {
      var request = new DeleteRoleProfilesRequest { RoleId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteRoleAsync(request)));
    }

    [Permissions]
    [HttpGet("roles")]
    public async Task<IActionResult> GetRolesAsync([FromQuery] GetRolesProfilesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetRolesAsync(request)));
    }

    [Permissions]
    [HttpPost("skill")]
    public async Task<IActionResult> RegisterSkillAsync(
      [FromBody] RegisterSkillProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.RegisterSkillAsync(request)));
    }

    [Permissions]
    [HttpPut("skill/{id}")]
    public async Task<IActionResult> UpdateSkillAsync(
      string id,
      [FromBody] UpdateSkillProfilesRequest request
    )
    {
      request.SkillId = id;
      return await HandleAsync(
        async () => Ok(await _profilesService.UpdateSkillRoleAsync(request))
      );
    }

    [Permissions]
    [HttpDelete("skill/{id}")]
    public async Task<IActionResult> DeleteSkillAsync(string id)
    {
      var request = new DeleteSkillProfilesRequest { SkillId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteSkillAsync(request)));
    }

    [Permissions]
    [HttpGet("skills")]
    public async Task<IActionResult> GetSkillsAsync([FromQuery] GetSkillsProfilesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetSkillAsync(request)));
    }

    [Permissions]
    [HttpPost("professional")]
    public async Task<IActionResult> RegisterProfessionalAsync(
      [FromBody] RegisterProfessionalProfilesRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterProfessionalAsync(request))
      );
    }

    [Permissions]
    [HttpPut("professional/{id}")]
    public async Task<IActionResult> UpdateProfessionalAsync(
      string id,
      [FromBody] UpdateProfessionalProfilesRequest request
    )
    {
      request.ProfessionalId = id;
      return await HandleAsync(
        async () => Ok(await _profilesService.UpdateProfessionalAsync(request))
      );
    }

    [Permissions]
    [HttpDelete("professional/{id}")]
    public async Task<IActionResult> DeleteProfessionalAsync(string id)
    {
      var request = new DeleteProfessionalProfilesRequest { ProfessionalId = id };
      return await HandleAsync(
        async () => Ok(await _profilesService.DeleteProfessionalAsync(request))
      );
    }

    [Permissions]
    [HttpGet("professionals")]
    public async Task<IActionResult> GetProfessionalsAsync(
      [FromQuery] GetProfessionalsProfilesRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.GetProfessionalAsync(request))
      );
    }

    [Permissions]
    [HttpPost("subskill")]
    public async Task<IActionResult> RegisterSubSkillAsync(
      [FromBody] RegisterSubSkillProfilesRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterSubSkillAsync(request))
      );
    }

    [Permissions]
    [HttpPut("subskill/{id}")]
    public async Task<IActionResult> UpdateSubSkillAsync(
      string id,
      [FromBody] UpdateSubSkillProfilesRequest request
    )
    {
      request.SubSkillId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateSubSkillAsync(request)));
    }

    [Permissions]
    [HttpDelete("subskill/{id}")]
    public async Task<IActionResult> DeleteSubSkillAsync(string id)
    {
      var request = new DeleteSubSkillProfilesRequest { SubSkillId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteSubSkillAsync(request)));
    }

    [Permissions]
    [HttpGet("subskills")]
    public async Task<IActionResult> GetSubSkillsAsync(
      [FromQuery] GetSubSkillsProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetSubSkillsAsync(request)));
    }

    [Permissions]
    [HttpPost("squad")]
    public async Task<IActionResult> RegisterSquadAsync(
      [FromBody] RegisterSquadProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.RegisterSquadAsync(request)));
    }

    [Permissions]
    [HttpPut("squad/{id}")]
    public async Task<IActionResult> UpdateSquadAsync(
      string id,
      [FromBody] UpdateSquadProfilesRequest request
    )
    {
      request.SquadId = id;
      return await HandleAsync(async () => Ok(await _profilesService.UpdateSquadAsync(request)));
    }

    [Permissions]
    [HttpDelete("squad/{id}")]
    public async Task<IActionResult> DeleteSquadAsync(string id)
    {
      var request = new DeleteSquadProfilesRequest { SquadId = id };
      return await HandleAsync(async () => Ok(await _profilesService.DeleteSquadAsync(request)));
    }

    [Permissions]
    [HttpGet("squads")]
    public async Task<IActionResult> GetSquadsAsync([FromQuery] GetSquadsProfilesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetSquadsAsync(request)));
    }

    [Permissions]
    [HttpPost("assessment")]
    public async Task<IActionResult> RegisterAssessmentAsync(
      [FromBody] RegisterAssessmentProfilesRequest request
    )
    {
      return await HandleAsync(
        async () => Ok(await _profilesService.RegisterAssessmentAsync(request))
      );
    }

    [Permissions]
    [HttpPut("assessment/{id}")]
    public async Task<IActionResult> UpdateAssessmentAsync(
      string id,
      [FromBody] UpdateAssessmentProfilesRequest request
    )
    {
      request.AssessmentId = id;
      return await HandleAsync(
        async () => Ok(await _profilesService.UpdateAssessmentAsync(request))
      );
    }

    [Permissions]
    [HttpDelete("assessment/{id}")]
    public async Task<IActionResult> DeleteAssessmentAsync(string id)
    {
      var request = new DeleteAssessmentProfilesRequest { AssessmentId = id };
      return await HandleAsync(
        async () => Ok(await _profilesService.DeleteAssessmentAsync(request))
      );
    }

    [Permissions]
    [HttpGet("assessments")]
    public async Task<IActionResult> GetAssessmentsAsync(
      [FromQuery] GetAssessmentsProfilesRequest request
    )
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetAssessmentsAsync(request)));
    }

    [HttpGet("podiums")]
    public async Task<IActionResult> GetPodiumsAsync([FromQuery] GetPodiumProfilesRequest request)
    {
      return await HandleAsync(async () => Ok(await _profilesService.GetPodiumsAsync(request)));
    }
  }
}
