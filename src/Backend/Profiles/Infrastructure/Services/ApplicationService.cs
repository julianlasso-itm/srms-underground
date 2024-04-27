using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace Profiles.Infrastructure.Services;

public class ApplicationService
{
    private readonly Application<RoleModel> _application;

    public ApplicationService(
        SharedEventHandler eventHandler,
        IRoleRepository<RoleModel> roleRepository
    )
    {
        _application = new Application<RoleModel>(roleRepository)
        {
            AggregateRoot = new PersonnelAggregateRoot(eventHandler)
        };
    }

    public Application<RoleModel> GetApplication()
    {
        return _application;
    }
}
