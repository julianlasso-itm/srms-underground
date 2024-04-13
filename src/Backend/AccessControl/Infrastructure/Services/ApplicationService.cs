using AccessControl.Application;
using AccessControl.Application.Repositories;
using AccessControl.Domain.Aggregates;
using AccessControl.Infrastructure.Events;
using AccessControl.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Services;

public class ApplicationService
{
    private readonly Application<User, Role> _application;

    public ApplicationService(
        IUserRepository<User> userRepository,
        RegisterUserEvent registerUserEvent,
        IRoleRepository<Role> roleRepository
    )
    {
        _application = new Application<User, Role>(userRepository, roleRepository)
        {
            AggregateRoot = new SecurityAggregateRoot(registerUserEvent)
        };
    }

    public Application<User, Role> GetApplication()
    {
        return _application;
    }
}
