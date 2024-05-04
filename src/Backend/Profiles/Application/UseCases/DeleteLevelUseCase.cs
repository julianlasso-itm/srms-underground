using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public sealed class DeleteLevelUseCase<TEntity>
    : BaseUseCase<DeleteLevelCommand, DeleteLevelApplicationResponse, IPersonnelAggregateRoot>
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository;

    public DeleteLevelUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      ILevelRepository<TEntity> levelRepository
    )
      : base(aggregateRoot)
    {
      _levelRepository = levelRepository;
    }

    public override async Task<DeleteLevelApplicationResponse> Handle(DeleteLevelCommand request)
    {
      var dataDeleteLevel = MapToRequestForDomain(request);
      var level = AggregateRoot.DeleteLevel(dataDeleteLevel);
      var response = MapToResponse(level);
      _ = await Persistence(response);
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
