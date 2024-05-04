using Analytics.Application.AntiCorruption.Interfaces;
using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Application.UseCases;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application
{
  public class Application<TLevelEntity>
    : BaseApplication<IAggregateRoot, IApplicationToDomain, IDomainToApplication>
    where TLevelEntity : class
  {
    private readonly ILevelRepository<TLevelEntity> _levelRepository;

    public Application(
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication,
      ILevelRepository<TLevelEntity> levelRepository
    )
      : base(applicationToDomain, domainToApplication)
    {
      _levelRepository = levelRepository;
    }

    public Task<RegisterLevelApplicationResponse> RegisterLevel(RegisterLevelCommand request)
    {
      var useCase = new RegisterLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<UpdateLevelApplicationResponse> UpdateLevel(UpdateLevelCommand request)
    {
      var useCase = new UpdateLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<DeleteLevelApplicationResponse> DeleteLevel(DeleteLevelCommand request)
    {
      var useCase = new DeleteLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<GetLevelsApplicationResponse<TLevelEntity>> GetLevels(GetLevelsCommand request)
    {
      var useCase = new GetLevelsUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }
  }
}
