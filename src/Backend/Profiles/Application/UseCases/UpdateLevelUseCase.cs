using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public sealed class UpdateLevelUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ILevelRepository<TEntity> levelRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateLevelCommand,
      UpdateLevelApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository = levelRepository;

    public override async Task<UpdateLevelApplicationResponse> Handle(UpdateLevelCommand request)
    {
      var dataUpdateLevel = MapToRequestForDomain(request);
      var level = AggregateRoot.UpdateLevel(dataUpdateLevel);
      var response = MapToResponse(level);
      _ = await Persistence(response);
      return response;
    }

    private UpdateLevelDomainRequest MapToRequestForDomain(UpdateLevelCommand request)
    {
      return new UpdateLevelDomainRequest
      {
        LevelId = request.LevelId,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable,
      };
    }

    private UpdateLevelApplicationResponse MapToResponse(UpdateLevelDomainResponse level)
    {
      return new UpdateLevelApplicationResponse
      {
        LevelId = level.LevelId,
        Name = level.Name,
        Description = level.Description,
        Disabled = level.Disabled,
      };
    }

    private async Task<TEntity> Persistence(UpdateLevelApplicationResponse response)
    {
      return await _levelRepository.UpdateAsync(Guid.Parse(response.LevelId), response);
    }
  }
}
