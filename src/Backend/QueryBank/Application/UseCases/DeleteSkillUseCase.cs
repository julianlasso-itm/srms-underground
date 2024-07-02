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

namespace QueryBank.Application.UseCases
{
  internal class DeleteSkillUseCase<TSkillEntity>
    : BaseUseCase<
      DeleteSkillCommand,
      DeleteSkillApplicationResponse,
      ICatalogAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TSkillEntity : class
  {
    private ISkillRepository<TSkillEntity> _skillRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillDeleted}";

    public DeleteSkillUseCase(
      ICatalogAggregateRoot aggregateRoot,
      ISkillRepository<TSkillEntity> skillRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      {
        _skillRepository = skillRepository;
      }
    }

    public override async Task<Result<DeleteSkillApplicationResponse>> Handle(
      DeleteSkillCommand request
    )
    {
      var dataDeleteRole = MapToRequestForDomain(request);
      var role = AggregateRoot.DeleteSkill(dataDeleteRole);

      if (role.IsFailure)
      {
        return Response<DeleteSkillApplicationResponse>.Failure(
          role.Message,
          role.Code,
          role.Details
        );
      }

      var response = MapToResponse(role.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return Response<DeleteSkillApplicationResponse>.Success(response);
    }

    private async Task<TSkillEntity> Persistence(DeleteSkillApplicationResponse response)
    {
      return await _skillRepository.DeleteAsync(Guid.Parse(response.SkillId));
    }

    private DeleteSkillDomainRequest MapToRequestForDomain(DeleteSkillCommand request)
    {
      return new DeleteSkillDomainRequest { SkillId = request.SkillId };
    }

    private DeleteSkillApplicationResponse MapToResponse(DeleteSkillDomainResponse skill)
    {
      return new DeleteSkillApplicationResponse { SkillId = skill.SkillId };
    }
  }
}
