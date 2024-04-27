using System.Text.Json;
using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Constants;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases;

public sealed class UpdateLevelUseCase<TEntity>
    : BaseUseCase<UpdateLevelCommand, UpdateLevelApplicationResponse, IAggregateRoot>
    where TEntity : class
{
    private readonly ILevelRepository<TEntity> _questionRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventLevelUpdated}";

    public UpdateLevelUseCase(
        IAggregateRoot aggregateRoot,
        ILevelRepository<TEntity> levelRepository
    )
        : base(aggregateRoot)
    {
        // _levelRepository = levelRepository;
    }

    public override async Task<UpdateLevelApplicationResponse> Handle(UpdateLevelCommand request)
    {
        throw new NotImplementedException();
        // var dataUpdateLevel = MapToRequestForDomain(request);
        // var question = AggregateRoot.UpdateLevel(dataUpdateLevel);
        // var response = MapToResponse(question);
        // _ = await Persistence(response);
        // EmitEvent(Channel, JsonSerializer.Serialize(response));
        // return response;
    }

    // private UpdateLevelDomainRequest MapToRequestForDomain(UpdateLevelCommand request)
    // {
    //     return new UpdateLevelDomainRequest
    //     {
    //         LevelId = request.LevelId,
    //         Level = request.Level,
    //         Disable = request.Disable,
    //     };
    // }

    // private UpdateLevelApplicationResponse MapToResponse(UpdateLevelDomainResponse level)
    // {
    //     return new UpdateLevelApplicationResponse
    //     {
    //         LevelId = level.LevelId,
    //         Level = level.Level,
    //         Disable = level.Disable,
    //     };
    // }

    // private async Task<TEntity> Persistence(UpdateLevelApplicationResponse response)
    // {
    //     return await _levelRepository.UpdateAsync(Guid.Parse(response.LevelId), response);
    // }
}
