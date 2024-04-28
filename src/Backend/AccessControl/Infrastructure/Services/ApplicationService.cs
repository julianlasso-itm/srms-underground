using AccessControl.Application;
using AccessControl.Application.Repositories;
using AccessControl.Domain.Aggregates;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace AccessControl.Infrastructure.Services;

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
            AggregateRoot = new SecurityAggregateRoot(eventHandler)
        };
    }

    public Application<RoleModel> GetApplication()
    {
        return _application;
    }
}
