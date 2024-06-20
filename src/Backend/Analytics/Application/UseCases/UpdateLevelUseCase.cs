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
using Shared.Common;
using Shared.Common.Bases;

namespace Analytics.Application.UseCases
{
  public sealed class UpdateLevelUseCase<TEntity>(
    IAggregateRoot aggregateRoot,
    ILevelRepository<TEntity> levelRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateLevelCommand,
      UpdateLevelApplicationResponse,
      IAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository = levelRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventLevelUpdated}";

    public override async Task<Result<UpdateLevelApplicationResponse>> Handle(
      UpdateLevelCommand request
    )
    {
      var dataUpdateLevel = MapToRequestForDomain(request);
      var level = AggregateRoot.UpdateLevel(dataUpdateLevel);

      if (level.IsFailure)
      {
        return Response<UpdateLevelApplicationResponse>.Failure(
          level.Message,
          level.Code,
          level.Details
        );
      }

      var response = MapToResponse(level.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateLevelApplicationResponse>.Success(response);
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
