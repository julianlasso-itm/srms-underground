using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services
{
  internal class ProfilesService : IProfilesServices
  {
    private readonly ApplicationService _applicationService;
    private readonly ISubSkillRepository<SubSkillModel> _subSkillRepository;
    private readonly ISquadRepository<SquadModel> _squadRepository;
    private readonly IAssessmentRepository<AssessmentModel> _assessmentRepository;

    public ProfilesService(
      ApplicationService applicationService,
      ISubSkillRepository<SubSkillModel> subSkillRepository,
      ISquadRepository<SquadModel> squadRepository,
      IAssessmentRepository<AssessmentModel> assessmentRepository
    )
    {
      _applicationService = applicationService;
      _subSkillRepository = subSkillRepository;
      _squadRepository = squadRepository;
      _assessmentRepository = assessmentRepository;
    }

    public Task<DeleteCityProfilesResponse> DeleteCityAsync(
      DeleteCityProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteCityHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCityHelper.DeleteCityAsync(request);
    }

    public Task<DeleteCountryProfilesResponse> DeleteCountryAsync(
      DeleteCountryProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteCountryHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCountryHelper.DeleteCountryAsync(request);
    }

    public Task<DeleteProvinceProfilesResponse> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteProvinceHelper.SetApplication(_applicationService.GetApplication());
      return DeleteProvinceHelper.DeleteProvinceAsync(request);
    }

    public Task<GetCitiesProfilesResponse> GetCitiesAsync(
      GetCitiesProfilesRequest request,
      CallContext context = default
    )
    {
      GetCitiesHelper.SetApplication(_applicationService.GetApplication());
      return GetCitiesHelper.GetCitiesAsync(request);
    }

    public Task<GetCountriesProfilesResponse> GetCountriesAsync(
      GetCountriesProfilesRequest request,
      CallContext context = default
    )
    {
      GetCountriesHelper.SetApplication(_applicationService.GetApplication());
      return GetCountriesHelper.GetCountriesAsync(request);
    }

    public Task<GetProvincesProfilesResponse> GetProvincesAsync(
      GetProvincesProfilesRequest request,
      CallContext context = default
    )
    {
      GetProvincesHelper.SetApplication(_applicationService.GetApplication());
      return GetProvincesHelper.GetProvincesAsync(request);
    }

    public Task<RegisterCityProfilesResponse> RegisterCityAsync(
      RegisterCityProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterCityHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCityHelper.RegisterCityAsync(request);
    }

    public Task<RegisterCountryProfilesResponse> RegisterCountryAsync(
      RegisterCountryProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterCountryHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCountryHelper.RegisterCountryAsync(request);
    }

    public Task<RegisterProvinceProfilesResponse> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterProvinceHelper.SetApplication(_applicationService.GetApplication());
      return RegisterProvinceHelper.RegisterProvinceAsync(request);
    }

    public Task<UpdateCityProfilesResponse> UpdateCityAsync(
      UpdateCityProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateCityHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCityHelper.UpdateCityAsync(request);
    }

    public Task<UpdateCountryProfilesResponse> UpdateCountryAsync(
      UpdateCountryProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateCountryHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCountryHelper.UpdateCountryAsync(request);
    }

    public Task<UpdateProvinceProfilesResponse> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateProvinceHelper.SetApplication(_applicationService.GetApplication());
      return UpdateProvinceHelper.UpdateProvinceAsync(request);
    }

    public Task<DeleteRoleProfilesResponse> DeleteRoleAsync(
      DeleteRoleProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
      return DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public Task<GetRolesProfilesResponse> GetRolesAsync(
      GetRolesProfilesRequest request,
      CallContext context = default
    )
    {
      GetRolesHelper.SetApplication(_applicationService.GetApplication());
      return GetRolesHelper.GetRolesAsync(request);
    }

    public Task<RegisterRoleProfilesResponse> RegisterRoleAsync(
      RegisterRoleProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
      return RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public Task<UpdateRoleProfilesResponse> UpdateRoleAsync(
      UpdateRoleProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
      return UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<DeleteProfessionalProfilesResponse> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteProfessionalHelper.DeleteProfessionalAsync(request);
    }

    public async Task<DeleteSkillProfilesResponse> DeleteSkillAsync(
      DeleteSkillProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteSkillHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteSkillHelper.DeleteSkillAsync(request);
    }

    public async Task<GetProfessionalProfilesResponse> GetProfessionalAsync(
      GetProfessionalsProfilesRequest request,
      CallContext context = default
    )
    {
      GetProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await GetProfessionalHelper.GetProfessionalsAsync(request);
    }

    public async Task<GetSkillsProfilesResponse> GetSkillAsync(
      GetSkillsProfilesRequest request,
      CallContext context = default
    )
    {
      GetSkillsHelper.SetApplication(_applicationService.GetApplication());
      return await GetSkillsHelper.GetSkillsAsync(request);
    }

    public async Task<RegisterProfessionalProfilesResponse> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterProfessionalHelper.RegisterProfessionalAsync(request);
    }

    public async Task<RegisterSkillProfilesResponse> RegisterSkillAsync(
      RegisterSkillProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterSkillHelper.RegisterSkillAsync(request);
    }

    public async Task<UpdateProfessionalProfilesResponse> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateProfessionalHelper.UpdateProfessionalAsync(request);
    }

    public async Task<UpdateSkillProfilesResponse> UpdateSkillRoleAsync(
      UpdateSkillProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateSkillHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateSkillHelper.UpdateSkillAsync(request);
    }

    public async Task<RegisterSubSkillProfilesResponse> RegisterSubSkillAsync(
      RegisterSubSkillProfilesRequest request,
      CallContext context = default
    )
    {
      var subskill = new SubSkillModel
      {
        SubSkillId = Guid.NewGuid(),
        SkillId = Guid.Parse(request.SkillId),
        Name = request.Name,
        Disabled = false,
      };
      var result = await _subSkillRepository.AddAsync(subskill);
      return new RegisterSubSkillProfilesResponse
      {
        SubSkillId = result.SubSkillId.ToString(),
        SkillId = result.SkillId.ToString(),
        Name = result.Name,
        Disabled = result.Disabled,
      };
    }

    public async Task<UpdateSubSkillProfilesResponse> UpdateSubSkillAsync(
      UpdateSubSkillProfilesRequest request,
      CallContext context = default
    )
    {
      var subskill = new UpdateSubSkillApplicationResponse
      {
        SubSkillId = request.SubSkillId!,
        SkillId = request.SkillId,
        Name = request.Name,
        Disabled = !request.Disable,
      };
      var result = await _subSkillRepository.UpdateAsync(Guid.Parse(request.SubSkillId!), subskill);
      return new UpdateSubSkillProfilesResponse
      {
        SubSkillId = result.SubSkillId.ToString(),
        SkillId = result.SkillId.ToString(),
        Name = result.Name,
        Disabled = result.Disabled,
      };
    }

    public async Task<DeleteSubSkillProfilesResponse> DeleteSubSkillAsync(
      DeleteSubSkillProfilesRequest request,
      CallContext context = default
    )
    {
      var result = await _subSkillRepository.DeleteAsync(Guid.Parse(request.SubSkillId));
      return new DeleteSubSkillProfilesResponse { SubSkillId = result.SubSkillId.ToString() };
    }

    public async Task<GetSubSkillsProfilesResponse> GetSubSkillsAsync(
      GetSubSkillsProfilesRequest request,
      CallContext context = default
    )
    {
      var results = await _subSkillRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort,
        request.Order ?? "asc",
        request.Filter,
        request.FilterBy
      );
      var total = await _subSkillRepository.GetCountAsync(request.Filter, request.FilterBy);
      return new GetSubSkillsProfilesResponse
      {
        SubSkills = results
          .Select(subskill => new SubSkillProfiles
          {
            SubSkillId = subskill.SubSkillId.ToString(),
            SkillId = subskill.SkillId.ToString(),
            Name = subskill.Name,
            Disabled = subskill.Disabled,
          })
          .ToList(),
        Total = total,
      };
    }

    public async Task<RegisterSquadProfilesResponse> RegisterSquadAsync(
      RegisterSquadProfilesRequest request,
      CallContext context = default
    )
    {
      var squad = new SquadModel
      {
        SquadId = Guid.NewGuid(),
        Name = request.Name,
        Disabled = false,
      };
      var result = await _squadRepository.AddAsync(squad);
      return new RegisterSquadProfilesResponse
      {
        SquadId = result.SquadId.ToString(),
        Name = result.Name,
        Disabled = result.Disabled,
      };
    }

    public async Task<UpdateSquadProfilesResponse> UpdateSquadAsync(
      UpdateSquadProfilesRequest request,
      CallContext context = default
    )
    {
      var squad = new UpdateSquadApplicationResponse
      {
        SquadId = request.SquadId!,
        Name = request.Name,
        Disabled = !request.Disable,
      };
      var result = await _squadRepository.UpdateAsync(Guid.Parse(request.SquadId!), squad);
      return new UpdateSquadProfilesResponse
      {
        SquadId = result.SquadId.ToString(),
        Name = result.Name,
        Disabled = result.Disabled,
      };
    }

    public async Task<DeleteSquadProfilesResponse> DeleteSquadAsync(
      DeleteSquadProfilesRequest request,
      CallContext context = default
    )
    {
      var result = await _squadRepository.DeleteAsync(Guid.Parse(request.SquadId));
      return new DeleteSquadProfilesResponse { SquadId = result.SquadId.ToString() };
    }

    public async Task<GetSquadsProfilesResponse> GetSquadsAsync(
      GetSquadsProfilesRequest request,
      CallContext context = default
    )
    {
      var results = await _squadRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort,
        request.Order ?? "asc",
        request.Filter,
        request.FilterBy
      );
      var total = await _squadRepository.GetCountAsync(request.Filter, request.FilterBy);
      return new GetSquadsProfilesResponse
      {
        Squads = results
          .Select(squad => new SquadProfiles
          {
            SquadId = squad.SquadId.ToString(),
            Name = squad.Name,
            Disabled = squad.Disabled,
          })
          .ToList(),
        Total = total,
      };
    }

    public async Task<RegisterAssessmentProfilesResponse> RegisterAssessmentAsync(
      RegisterAssessmentProfilesRequest request,
      CallContext context = default
    )
    {
      var assessment = new RegisterAssessmentApplicationResponse
      {
        AssessmentId = Guid.NewGuid().ToString(),
        ProfessionalId = request.ProfessionalId,
        RoleId = request.RoleId,
        SquadId = request.SquadId,
      };
      var result = await _assessmentRepository.AddAsync(assessment);
      return new RegisterAssessmentProfilesResponse
      {
        AssessmentId = result.AssessmentId.ToString(),
        ProfessionalId = result.ProfessionalId.ToString(),
        RoleId = result.RoleId.ToString(),
        SquadId = result.SquadId.ToString(),
      };
    }

    public async Task<UpdateAssessmentProfilesResponse> UpdateAssessmentAsync(
      UpdateAssessmentProfilesRequest request,
      CallContext context = default
    )
    {
      var assessment = new UpdateAssessmentApplicationResponse
      {
        ProfessionalId = request.ProfessionalId,
        RoleId = request.RoleId,
        SquadId = request.SquadId,
      };
      var result = await _assessmentRepository.UpdateAsync(
        Guid.Parse(request.AssessmentId!),
        assessment
      );
      return new UpdateAssessmentProfilesResponse
      {
        AssessmentId = result.AssessmentId.ToString(),
        ProfessionalId = result.ProfessionalId.ToString(),
        RoleId = result.RoleId.ToString(),
        SquadId = result.SquadId.ToString(),
      };
    }

    public async Task<DeleteAssessmentProfilesResponse> DeleteAssessmentAsync(
      DeleteAssessmentProfilesRequest request,
      CallContext context = default
    )
    {
      var result = await _assessmentRepository.DeleteAsync(Guid.Parse(request.AssessmentId));
      return new DeleteAssessmentProfilesResponse { AssessmentId = result.AssessmentId.ToString() };
    }

    public async Task<GetAssessmentsProfilesResponse> GetAssessmentsAsync(
      GetAssessmentsProfilesRequest request,
      CallContext context = default
    )
    {
      var results = await _assessmentRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort,
        request.Order ?? "asc",
        request.Filter,
        request.FilterBy
      );
      var total = await _assessmentRepository.GetCountAsync(request.Filter, request.FilterBy);
      return new GetAssessmentsProfilesResponse
      {
        Assessments = results
          .Select(assessment => new AssessmentProfiles
          {
            AssessmentId = assessment.AssessmentId.ToString(),
            ProfessionalId = assessment.ProfessionalId.ToString(),
            RoleId = assessment.RoleId.ToString(),
            SquadId = assessment.SquadId.ToString(),
            Professional = new ProfessionalProfiles
            {
              ProfessionalId = assessment.Professional.ProfessionalId.ToString(),
              Name = assessment.Professional.Name,
              Email = assessment.Professional.Email,
              Disabled = assessment.Professional.Disabled,
            },
            Role = new RoleProfiles
            {
              RoleId = assessment.Role.RoleId.ToString(),
              Name = assessment.Role.Name,
              Description = assessment.Role.Description,
              Disabled = assessment.Role.Disabled,
            },
            Squad = new SquadProfiles
            {
              SquadId = assessment.Squad.SquadId.ToString(),
              Name = assessment.Squad.Name,
              Disabled = assessment.Squad.Disabled,
            },
            Skills = assessment
              .Role.RolePerSkills.Select(rolePerSkill => new SkillWithSubSkillsProfiles
              {
                SkillId = rolePerSkill.Skill.SkillId.ToString(),
                Name = rolePerSkill.Skill.Name,
                Disabled = rolePerSkill.Skill.Disabled,
                SubSkills = rolePerSkill
                  .Skill.SubSkills.Select(subskill => new SubSkillWithResultProfiles
                  {
                    SubSkillId = subskill.SubSkillId.ToString(),
                    SkillId = subskill.SkillId.ToString(),
                    Name = subskill.Name,
                    Disabled = subskill.Disabled,
                    Results = subskill.Results.Select(result => new ResultProfiles
                    {
                      ResultId = result.ResultId.ToString(),
                      AssessmentId = result.AssessmentId.ToString(),
                      SubSkillId = result.SubSkillId.ToString(),
                      Result = result.Result,
                      Comment = result.Comment,
                      DateTime = result.DateTime ?? DateTime.UtcNow,
                    })
                  })
                  .ToList(),
              })
              .ToList(),
          })
          .ToList(),
        Total = total,
      };
    }
  }
}
