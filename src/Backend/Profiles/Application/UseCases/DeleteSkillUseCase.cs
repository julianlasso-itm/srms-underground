using System.Text.Json;
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
using Shared.Common;

namespace Profiles.Application.UseCases
{
  internal class DeleteSkillUseCase<TSkillEntity>
    : BaseUseCase<
      DeleteSkillCommand,
      DeleteSkillApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TSkillEntity : class
  {
    private ISkillRepository<TSkillEntity> _skillRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillDeleted}";

    public DeleteSkillUseCase(
      IPersonnelAggregateRoot aggregateRoot,
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
