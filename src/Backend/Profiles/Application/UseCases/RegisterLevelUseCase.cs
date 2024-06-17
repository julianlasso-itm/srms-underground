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
  public sealed class RegisterLevelUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ILevelRepository<TEntity> levelRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterLevelCommand,
      RegisterLevelApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository = levelRepository;

    public override async Task<RegisterLevelApplicationResponse> Handle(
      RegisterLevelCommand request
    )
    {
      var newLevel = MapToRequestForDomain(request);
      var level = AggregateRoot.RegisterLevel(newLevel);
      var response = MapToResponse(level);
      _ = await Persistence(response);
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
