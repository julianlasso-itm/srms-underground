using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Application.UseCases;
using Analytics.Domain.Aggregates.Interfaces;

namespace Analytics.Application
{
  public class Application<TLevelEntity>
    where TLevelEntity : class
  {
    public required IAggregateRoot AggregateRoot { get; init; }

    private readonly ILevelRepository<TLevelEntity> _levelRepository;

    public Application(ILevelRepository<TLevelEntity> levelRepository)
    {
      _levelRepository = levelRepository;
    }

    public Task<RegisterLevelApplicationResponse> RegisterLevel(RegisterLevelCommand request)
    {
      var useCase = new RegisterLevelUseCase<TLevelEntity>(AggregateRoot, _levelRepository);
      return useCase.Handle(request);
    }

    public Task<UpdateLevelApplicationResponse> UpdateLevel(UpdateLevelCommand request)
    {
      var useCase = new UpdateLevelUseCase<TLevelEntity>(AggregateRoot, _levelRepository);
      return useCase.Handle(request);
    }

    public Task<DeleteLevelApplicationResponse> DeleteLevel(DeleteLevelCommand request)
    {
      var useCase = new DeleteLevelUseCase<TLevelEntity>(AggregateRoot, _levelRepository);
      return useCase.Handle(request);
    }

    public Task<GetLevelsApplicationResponse<TLevelEntity>> GetLevels(GetLevelsCommand request)
    {
      var useCase = new GetLevelsUseCase<TLevelEntity>(AggregateRoot, _levelRepository);
      return useCase.Handle(request);
    }
  }
}
