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
  public sealed class RegisterLevelUseCase<TEntity>(
    IAggregateRoot aggregateRoot,
    ILevelRepository<TEntity> levelRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterLevelCommand,
      RegisterLevelApplicationResponse,
      IAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository = levelRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventLevelRegistered}";

    public override async Task<RegisterLevelApplicationResponse> Handle(
      RegisterLevelCommand request
    )
    {
      var newLevel = MapToRequestForDomain(request);
      var level = AggregateRoot.RegisterLevel(newLevel);
      var response = MapToResponse(level);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private RegisterLevelDomainRequest MapToRequestForDomain(RegisterLevelCommand request)
    {
      return new RegisterLevelDomainRequest
      {
        Name = request.Name,
        Description = request.Description,
      };
    }

    private RegisterLevelApplicationResponse MapToResponse(RegisterLevelDomainResponse level)
    {
      return new RegisterLevelApplicationResponse
      {
        LevelId = level.LevelId,
        Name = level.Name,
        Description = level.Description,
        Disabled = level.Disabled,
      };
    }

    private async Task<TEntity> Persistence(RegisterLevelApplicationResponse response)
    {
      return await _levelRepository.AddAsync(response);
    }
  }
}
