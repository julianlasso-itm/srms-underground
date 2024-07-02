using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers;
using ProtoBuf.Grpc;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services
{
  internal class ProfilesService(
    ApplicationService applicationService,
    ISubSkillRepository<SubSkillModel> subSkillRepository,
    ISquadRepository<SquadModel> squadRepository,
    IAssessmentRepository<AssessmentModel> assessmentRepository,
    IPodiumRepository<PodiumModel> podiumRepository
  ) : IProfilesServices
  {
    private readonly ApplicationService _applicationService = applicationService;
    private readonly ISubSkillRepository<SubSkillModel> _subSkillRepository = subSkillRepository;
    private readonly ISquadRepository<SquadModel> _squadRepository = squadRepository;
    private readonly IAssessmentRepository<AssessmentModel> _assessmentRepository =
      assessmentRepository;
    private readonly IPodiumRepository<PodiumModel> _podiumRepository = podiumRepository;

    public Task<Result<DeleteCityProfilesResponse>> DeleteCityAsync(
      DeleteCityProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteCityHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCityHelper.DeleteCityAsync(request);
    }

    public Task<Result<DeleteCountryProfilesResponse>> DeleteCountryAsync(
      DeleteCountryProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteCountryHelper.SetApplication(_applicationService.GetApplication());
      return DeleteCountryHelper.DeleteCountryAsync(request);
    }

    public Task<Result<DeleteProvinceProfilesResponse>> DeleteProvinceAsync(
      DeleteProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteProvinceHelper.SetApplication(_applicationService.GetApplication());
      return DeleteProvinceHelper.DeleteProvinceAsync(request);
    }

    public Task<Result<GetCitiesProfilesResponse>> GetCitiesAsync(
      GetCitiesProfilesRequest request,
      CallContext context = default
    )
    {
      GetCitiesHelper.SetApplication(_applicationService.GetApplication());
      return GetCitiesHelper.GetCitiesAsync(request);
    }

    public Task<Result<GetCountriesProfilesResponse>> GetCountriesAsync(
      GetCountriesProfilesRequest request,
      CallContext context = default
    )
    {
      GetCountriesHelper.SetApplication(_applicationService.GetApplication());
      return GetCountriesHelper.GetCountriesAsync(request);
    }

    public Task<Result<GetProvincesProfilesResponse>> GetProvincesAsync(
      GetProvincesProfilesRequest request,
      CallContext context = default
    )
    {
      GetProvincesHelper.SetApplication(_applicationService.GetApplication());
      return GetProvincesHelper.GetProvincesAsync(request);
    }

    public Task<Result<RegisterCityProfilesResponse>> RegisterCityAsync(
      RegisterCityProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterCityHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCityHelper.RegisterCityAsync(request);
    }

    public Task<Result<RegisterCountryProfilesResponse>> RegisterCountryAsync(
      RegisterCountryProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterCountryHelper.SetApplication(_applicationService.GetApplication());
      return RegisterCountryHelper.RegisterCountryAsync(request);
    }

    public Task<Result<RegisterProvinceProfilesResponse>> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterProvinceHelper.SetApplication(_applicationService.GetApplication());
      return RegisterProvinceHelper.RegisterProvinceAsync(request);
    }

    public Task<Result<UpdateCityProfilesResponse>> UpdateCityAsync(
      UpdateCityProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateCityHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCityHelper.UpdateCityAsync(request);
    }

    public Task<Result<UpdateCountryProfilesResponse>> UpdateCountryAsync(
      UpdateCountryProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateCountryHelper.SetApplication(_applicationService.GetApplication());
      return UpdateCountryHelper.UpdateCountryAsync(request);
    }

    public Task<Result<UpdateProvinceProfilesResponse>> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateProvinceHelper.SetApplication(_applicationService.GetApplication());
      return UpdateProvinceHelper.UpdateProvinceAsync(request);
    }

    public Task<Result<DeleteRoleProfilesResponse>> DeleteRoleAsync(
      DeleteRoleProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteRoleHelper.SetApplication(_applicationService.GetApplication());
      return DeleteRoleHelper.DeleteRoleAsync(request);
    }

    public Task<Result<GetRolesProfilesResponse>> GetRolesAsync(
      GetRolesProfilesRequest request,
      CallContext context = default
    )
    {
      GetRolesHelper.SetApplication(_applicationService.GetApplication());
      return GetRolesHelper.GetRolesAsync(request);
    }

    public Task<Result<RegisterRoleProfilesResponse>> RegisterRoleAsync(
      RegisterRoleProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterRoleHelper.SetApplication(_applicationService.GetApplication());
      return RegisterRoleHelper.RegisterRoleAsync(request);
    }

    public Task<Result<UpdateRoleProfilesResponse>> UpdateRoleAsync(
      UpdateRoleProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateRoleHelper.SetApplication(_applicationService.GetApplication());
      return UpdateRoleHelper.UpdateRoleAsync(request);
    }

    public async Task<Result<DeleteProfessionalProfilesResponse>> DeleteProfessionalAsync(
      DeleteProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteProfessionalHelper.DeleteProfessionalAsync(request);
    }

    public async Task<Result<DeleteSkillProfilesResponse>> DeleteSkillAsync(
      DeleteSkillProfilesRequest request,
      CallContext context = default
    )
    {
      DeleteSkillHelper.SetApplication(_applicationService.GetApplication());
      return await DeleteSkillHelper.DeleteSkillAsync(request);
    }

    public async Task<Result<GetProfessionalProfilesResponse>> GetProfessionalAsync(
      GetProfessionalsProfilesRequest request,
      CallContext context = default
    )
    {
      GetProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await GetProfessionalHelper.GetProfessionalsAsync(request);
    }

    public async Task<Result<GetSkillsProfilesResponse>> GetSkillAsync(
      GetSkillsProfilesRequest request,
      CallContext context = default
    )
    {
      GetSkillsHelper.SetApplication(_applicationService.GetApplication());
      return await GetSkillsHelper.GetSkillsAsync(request);
    }

    public async Task<Result<RegisterProfessionalProfilesResponse>> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterProfessionalHelper.RegisterProfessionalAsync(request);
    }

    public async Task<Result<RegisterSkillProfilesResponse>> RegisterSkillAsync(
      RegisterSkillProfilesRequest request,
      CallContext context = default
    )
    {
      RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
      return await RegisterSkillHelper.RegisterSkillAsync(request);
    }

    public async Task<Result<UpdateProfessionalProfilesResponse>> UpdateProfessionalAsync(
      UpdateProfessionalProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateProfessionalHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateProfessionalHelper.UpdateProfessionalAsync(request);
    }

    public async Task<Result<UpdateSkillProfilesResponse>> UpdateSkillRoleAsync(
      UpdateSkillProfilesRequest request,
      CallContext context = default
    )
    {
      UpdateSkillHelper.SetApplication(_applicationService.GetApplication());
      return await UpdateSkillHelper.UpdateSkillAsync(request);
    }

    public async Task<Result<RegisterSubSkillProfilesResponse>> RegisterSubSkillAsync(
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
      return Response<RegisterSubSkillProfilesResponse>.Success(
        new RegisterSubSkillProfilesResponse
        {
          SubSkillId = result.SubSkillId.ToString(),
          SkillId = result.SkillId.ToString(),
          Name = result.Name,
          Disabled = result.Disabled,
        }
      );
    }

    public async Task<Result<UpdateSubSkillProfilesResponse>> UpdateSubSkillAsync(
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
      return Response<UpdateSubSkillProfilesResponse>.Success(
        new UpdateSubSkillProfilesResponse
        {
          SubSkillId = result.SubSkillId.ToString(),
          SkillId = result.SkillId.ToString(),
          Name = result.Name,
          Disabled = result.Disabled,
        }
      );
    }

    public async Task<Result<DeleteSubSkillProfilesResponse>> DeleteSubSkillAsync(
      DeleteSubSkillProfilesRequest request,
      CallContext context = default
    )
    {
      var result = await _subSkillRepository.DeleteAsync(Guid.Parse(request.SubSkillId));
      return Response<DeleteSubSkillProfilesResponse>.Success(
        new DeleteSubSkillProfilesResponse { SubSkillId = result.SubSkillId.ToString() }
      );
    }

    public async Task<Result<GetSubSkillsProfilesResponse>> GetSubSkillsAsync(
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
      return Response<GetSubSkillsProfilesResponse>.Success(
        new GetSubSkillsProfilesResponse
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
        }
      );
    }

    public async Task<Result<RegisterSquadProfilesResponse>> RegisterSquadAsync(
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
      return Response<RegisterSquadProfilesResponse>.Success(
        new RegisterSquadProfilesResponse
        {
          SquadId = result.SquadId.ToString(),
          Name = result.Name,
          Disabled = result.Disabled,
        }
      );
    }

    public async Task<Result<UpdateSquadProfilesResponse>> UpdateSquadAsync(
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
      return Response<UpdateSquadProfilesResponse>.Success(
        new UpdateSquadProfilesResponse
        {
          SquadId = result.SquadId.ToString(),
          Name = result.Name,
          Disabled = result.Disabled,
        }
      );
    }

    public async Task<Result<DeleteSquadProfilesResponse>> DeleteSquadAsync(
      DeleteSquadProfilesRequest request,
      CallContext context = default
    )
    {
      var result = await _squadRepository.DeleteAsync(Guid.Parse(request.SquadId));
      return Response<DeleteSquadProfilesResponse>.Success(
        new DeleteSquadProfilesResponse { SquadId = result.SquadId.ToString() }
      );
    }

    public async Task<Result<GetSquadsProfilesResponse>> GetSquadsAsync(
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
      return Response<GetSquadsProfilesResponse>.Success(
        new GetSquadsProfilesResponse
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
        }
      );
    }

    public async Task<Result<RegisterAssessmentProfilesResponse>> RegisterAssessmentAsync(
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
      return Response<RegisterAssessmentProfilesResponse>.Success(
        new RegisterAssessmentProfilesResponse
        {
          AssessmentId = result.AssessmentId.ToString(),
          ProfessionalId = result.ProfessionalId.ToString(),
          RoleId = result.RoleId.ToString(),
          SquadId = result.SquadId.ToString(),
        }
      );
    }

    public async Task<Result<UpdateAssessmentProfilesResponse>> UpdateAssessmentAsync(
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
      return Response<UpdateAssessmentProfilesResponse>.Success(
        new UpdateAssessmentProfilesResponse
        {
          AssessmentId = result.AssessmentId.ToString(),
          ProfessionalId = result.ProfessionalId.ToString(),
          RoleId = result.RoleId.ToString(),
          SquadId = result.SquadId.ToString(),
        }
      );
    }

    public async Task<Result<DeleteAssessmentProfilesResponse>> DeleteAssessmentAsync(
      DeleteAssessmentProfilesRequest request,
      CallContext context = default
    )
    {
      var result = await _assessmentRepository.DeleteAsync(Guid.Parse(request.AssessmentId));
      return Response<DeleteAssessmentProfilesResponse>.Success(
        new DeleteAssessmentProfilesResponse { AssessmentId = result.AssessmentId.ToString() }
      );
    }

    public async Task<Result<GetAssessmentsProfilesResponse>> GetAssessmentsAsync(
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

      var assessments = results
        .Select(assessment => new AssessmentProfiles
        {
          AssessmentId = assessment.AssessmentId.ToString(),
          ProfessionalId = assessment.ProfessionalId.ToString(),
          RoleId = assessment.RoleId.ToString(),
          SquadId = assessment.SquadId.ToString(),
          Professional =
            assessment.Professional != null
              ? new ProfessionalProfiles
              {
                ProfessionalId = assessment.Professional.ProfessionalId.ToString(),
                Name = assessment.Professional.Name,
                Email = assessment.Professional.Email,
                Disabled = assessment.Professional.Disabled,
              }
              : new ProfessionalProfiles(),
          Role =
            assessment.Role != null
              ? new RoleProfiles
              {
                RoleId = assessment.Role.RoleId.ToString(),
                Name = assessment.Role.Name,
                Description = assessment.Role.Description,
                Disabled = assessment.Role.Disabled,
              }
              : new RoleProfiles(),
          Squad =
            assessment.Squad != null
              ? new SquadProfiles
              {
                SquadId = assessment.Squad.SquadId.ToString(),
                Name = assessment.Squad.Name,
                Disabled = assessment.Squad.Disabled,
              }
              : new SquadProfiles(),
          Skills =
            assessment
              .Role?.RolePerSkills?.Select(rolePerSkill => new SkillWithSubSkillsProfiles
              {
                SkillId = rolePerSkill.Skill.SkillId.ToString(),
                Name = rolePerSkill.Skill.Name,
                Disabled = rolePerSkill.Skill.Disabled,
                SubSkills =
                  rolePerSkill
                    .Skill.SubSkills?.Select(subskill => new SubSkillWithResultProfiles
                    {
                      SubSkillId = subskill.SubSkillId.ToString(),
                      SkillId = subskill.SkillId.ToString(),
                      Name = subskill.Name,
                      Disabled = subskill.Disabled,
                      Results =
                        subskill
                          .Results?.Select(result => new ResultProfiles
                          {
                            ResultId = result.ResultId.ToString(),
                            AssessmentId = result.AssessmentId.ToString(),
                            SubSkillId = result.SubSkillId.ToString(),
                            Result = result.Result,
                            Comment = result.Comment,
                            DateTime = result.DateTime ?? DateTime.UtcNow,
                          })
                          .ToList() ?? []
                    })
                    .ToList() ?? []
              })
              .ToList() ?? []
        })
        .ToList();

      return Response<GetAssessmentsProfilesResponse>.Success(
        new GetAssessmentsProfilesResponse { Assessments = assessments, Total = total, }
      );
    }

    public async Task<Result<GetPodiumProfilesResponse>> GetPodiumsAsync(
      GetPodiumProfilesRequest request,
      CallContext context = default
    )
    {
      var podiums = await _podiumRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort,
        request.Order ?? "asc",
        request.Filter,
        request.FilterBy
      );
      var total = await _podiumRepository.GetCountAsync(request.Filter, request.FilterBy);
      return Response<GetPodiumProfilesResponse>.Success(
        new GetPodiumProfilesResponse
        {
          Podium = podiums
            .Select(podium => new PodiumProfiles
            {
              PodiumId = podium.PodiumId.ToString(),
              Name = podium.Name,
              Email = podium.Email,
              Photo = podium.Photo,
            })
            .ToList(),
          Total = total,
        }
      );
    }
  }
}
