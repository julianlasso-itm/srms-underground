using System.Text.Json;
using Analytics.Application.AntiCorruption.Interfaces;
using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Constants;
using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases
{
  public sealed class DeleteLevelUseCase<TEntity>(
    IAggregateRoot aggregateRoot,
    ILevelRepository<TEntity> levelRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteLevelCommand,
      DeleteLevelApplicationResponse,
      IAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository = levelRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventLevelDeleted}";

    public override async Task<DeleteLevelApplicationResponse> Handle(DeleteLevelCommand request)
    {
      var dataDeleteLevel = MapToRequestForDomain(request);
      var level = AggregateRoot.DeleteLevel(dataDeleteLevel);
      var response = MapToResponse(level);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private DeleteLevelDomainRequest MapToRequestForDomain(DeleteLevelCommand request)
    {
      return new DeleteLevelDomainRequest { LevelId = request.LevelId };
    }

    private DeleteLevelApplicationResponse MapToResponse(DeleteLevelDomainResponse level)
    {
      return new DeleteLevelApplicationResponse { LevelId = level.LevelId };
    }

    private async Task<TEntity> Persistence(DeleteLevelApplicationResponse response)
    {
      return await _levelRepository.DeleteAsync(Guid.Parse(response.LevelId));
    }
  }
}
