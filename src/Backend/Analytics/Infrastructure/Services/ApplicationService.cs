using Analytics.Application;
using Analytics.Application.Repositories;
using Analytics.Domain.Aggregates;
using Analytics.Infrastructure.Messaging.Events;
using Analytics.Infrastructure.Persistence.Models;

namespace Analytics.Infrastructure.Services;

public class ApplicationService
{
    private readonly Application<Level> _application;

    public ApplicationService(
        ILevelRepository<LevelModel> levelRepository
    )
    {
        _application = new Application<Level>(levelRepository)
        {
            AggregateRoot = new AggregateRoot(registerLevelEvent)
        };
    }

    public Application<Level> GetApplication()
    {
        return _application;
    }
}
