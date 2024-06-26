﻿using System.Text.Json;
using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;

namespace Profiles.Application.UseCases
{
  public class RegisterSkillUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ISkillRepository<TEntity> skillRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterSkillCommand,
      RegisterSkillApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ISkillRepository<TEntity> _skillRepository = skillRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillRegistered}";

    public override async Task<Result<RegisterSkillApplicationResponse>> Handle(
      RegisterSkillCommand request
    )
    {
      var newSkill = MapToRequestForDomain(request);
      var skill = AggregateRoot.RegisterSkill(newSkill);

      if (skill.IsFailure)
      {
        return Response<RegisterSkillApplicationResponse>.Failure(
          skill.Message,
          skill.Code,
          skill.Details
        );
      }

      var response = MapToResponse(skill.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<RegisterSkillApplicationResponse>.Success(response);
    }

    private RegisterSkillDomainRequest MapToRequestForDomain(RegisterSkillCommand request)
    {
      return new RegisterSkillDomainRequest { Name = request.Name, };
    }

    private RegisterSkillApplicationResponse MapToResponse(RegisterSkillDomainResponse skill)
    {
      return new RegisterSkillApplicationResponse
      {
        SkillId = skill.SkillId,
        Name = skill.Name,
        Disabled = skill.Disabled
      };
    }

    private async Task<TEntity> Persistence(RegisterSkillApplicationResponse response)
    {
      return await _skillRepository.AddAsync(response);
    }
  }
}
