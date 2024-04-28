using Analytics.Application;
using Analytics.Application.Repositories;
using Analytics.Domain.Aggregates;
using Analytics.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace Analytics.Infrastructure.Services;

public class ApplicationService
{
    private readonly Application<LevelModel> _application;

    public ApplicationService(
        SharedEventHandler eventHandler,
        ILevelRepository<LevelModel> levelRepository
    )
    {
        _application = new Application<LevelModel>(levelRepository)
        {
            AggregateRoot = new AggregateRoot(eventHandler)
        };
    }

    public Application<LevelModel> GetApplication()
    {
        return _application;
    }
}
