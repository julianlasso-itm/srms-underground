using AccessControl.Application;
using AccessControl.Application.Repositories;
using AccessControl.Domain.Aggregates;
using AccessControl.Infrastructure.Messaging.Events;
using AccessControl.Infrastructure.Persistence.Models;

namespace AccessControl.Infrastructure.Services;

public class ApplicationService
{
    private readonly Application<UserModel, RoleModel> _application;

    public ApplicationService(
        IUserRepository<UserModel> userRepository,
        RegisterUserEvent registerUserEvent,
        IRoleRepository<RoleModel> roleRepository
    )
    {
        _application = new Application<UserModel, RoleModel>(userRepository, roleRepository)
        {
            AggregateRoot = new SecurityAggregateRoot(registerUserEvent)
        };
    }

    public Application<UserModel, RoleModel> GetApplication()
    {
        return _application;
    }
}
