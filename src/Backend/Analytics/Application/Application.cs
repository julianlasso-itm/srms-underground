using Analytics.Application.AntiCorruption.Interfaces;
using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Application.UseCases;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;

namespace Analytics.Application
{
  public class Application<TLevelEntity>(
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication,
    ILevelRepository<TLevelEntity> levelRepository
  )
    : BaseApplication<IAggregateRoot, IApplicationToDomain, IDomainToApplication>(
      applicationToDomain,
      domainToApplication
    )
    where TLevelEntity : class
  {
    private readonly ILevelRepository<TLevelEntity> _levelRepository = levelRepository;

    public Task<Result<RegisterLevelApplicationResponse>> RegisterLevel(
      RegisterLevelCommand request
    )
    {
      var useCase = new RegisterLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateLevelApplicationResponse>> UpdateLevel(UpdateLevelCommand request)
    {
      var useCase = new UpdateLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteLevelApplicationResponse>> DeleteLevel(DeleteLevelCommand request)
    {
      var useCase = new DeleteLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<GetLevelsApplicationResponse<TLevelEntity>>> GetLevels(
      GetLevelsCommand request
    )
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
