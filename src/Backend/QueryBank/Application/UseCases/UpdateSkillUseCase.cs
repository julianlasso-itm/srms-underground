﻿using System.Text.Json;
using QueryBank.Application.AntiCorruption.Interfaces;
using QueryBank.Application.Commands;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Domain.Aggregates.Constants;
using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;

namespace QueryBank.Application.UseCases
{
  public class UpdateSkillUseCase<TSkillEntity>(
    ICatalogAggregateRoot aggregateRoot,
    ISkillRepository<TSkillEntity> skillRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateSkillCommand,
      UpdateSkillApplicationResponse,
      ICatalogAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository = skillRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillUpdated}";

    public override async Task<Result<UpdateSkillApplicationResponse>> Handle(
      UpdateSkillCommand request
    )
    {
      var dataUpdateSkill = MapToRequestForDomain(request);
      var skill = AggregateRoot.UpdateSkill(dataUpdateSkill);

      if (skill.IsFailure)
      {
        return Response<UpdateSkillApplicationResponse>.Failure(
          skill.Message,
          skill.Code,
          skill.Details
        );
      }
      var response = MapToResponse(skill.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateSkillApplicationResponse>.Success(response);
    }

    private UpdateSkillDomainRequest MapToRequestForDomain(UpdateSkillCommand request)
    {
      return new UpdateSkillDomainRequest
      {
        SkillId = request.SkillId,
        SubSkillId = request.SubSkillId,
        Name = request.Name,
        Disabled = request.Disabled,
      };
    }

    private UpdateSkillApplicationResponse MapToResponse(UpdateSkillDomainResponse skill)
    {
      return new UpdateSkillApplicationResponse
      {
        SkillId = skill.SkillId,
        SubSkillId = skill.SubSkillId,
        Name = skill.Name,
        Disabled = skill.Disabled,
      };
    }

    private async Task<TSkillEntity> Persistence(UpdateSkillApplicationResponse response)
    {
      return await _skillRepository.UpdateAsync(Guid.Parse(response.SkillId), response);
    }
  }
}
