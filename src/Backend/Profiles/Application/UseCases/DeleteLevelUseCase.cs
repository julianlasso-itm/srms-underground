using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common;

namespace Profiles.Application.UseCases
{
  public sealed class DeleteLevelUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ILevelRepository<TEntity> levelRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteLevelCommand,
      DeleteLevelApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository = levelRepository;

    public override async Task<Result<DeleteLevelApplicationResponse>> Handle(
      DeleteLevelCommand request
    )
    {
      var dataDeleteLevel = MapToRequestForDomain(request);
      var level = AggregateRoot.DeleteLevel(dataDeleteLevel);

      if (level.IsFailure)
      {
        return Response<DeleteLevelApplicationResponse>.Failure(
          level.Message,
          level.Code,
          level.Details
        );
      }

      var response = MapToResponse(level.Data);
      _ = await Persistence(response);

      return Response<DeleteLevelApplicationResponse>.Success(response);
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
