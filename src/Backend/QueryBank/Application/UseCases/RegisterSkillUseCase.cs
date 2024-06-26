using System.Text.Json;
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
  public class RegisterSkillUseCase<TEntity>(
    ICatalogAggregateRoot aggregateRoot,
    ISkillRepository<TEntity> skillRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterSkillCommand,
      RegisterSkillApplicationResponse,
      ICatalogAggregateRoot,
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
      return new RegisterSkillDomainRequest
      {
        SkillId = request.SkillId,
        SubSkillId = request.SubSkillId,
        Name = request.Name,
        Disable = request.Disable,
      };
    }

    private RegisterSkillApplicationResponse MapToResponse(RegisterSkillDomainResponse skill)
    {
      return new RegisterSkillApplicationResponse
      {
        SkillId = skill.SkillId,
        SubSkillId = skill.SubSkillId,
        Name = skill.Name,
        Disabled = skill.Disabled,
      };
    }

    private async Task<TEntity> Persistence(RegisterSkillApplicationResponse response)
    {
      return await _skillRepository.AddAsync(response);
    }
  }
}
