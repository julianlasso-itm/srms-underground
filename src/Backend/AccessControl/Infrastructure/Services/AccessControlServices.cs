using AccessControl.Application;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Domain.Aggregates;
using AccessControl.Infrastructure.Events;
using AccessControl.Infrastructure.Persistence.Models;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services;

public class AccessControlServices : IAccessControlServices
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IRoleRepository<Role> _roleRepository;
    private readonly RegisterUserEvent _registerUserEvent;

    public AccessControlServices(
        IUserRepository<User> userRepository,
        RegisterUserEvent registerUserEvent,
        IRoleRepository<Role> roleRepository
    )
    {
        _userRepository = userRepository;
        _registerUserEvent = registerUserEvent;
        _roleRepository = roleRepository;
    }

    public async Task<RegisterUserResponse> RegisterUserAsync(
        RegisterUserRequest request,
        CallContext context = default
    )
    {
        var app = new Application<User, Role>(_userRepository, _roleRepository)
        {
            AggregateRoot = new SecurityAggregateRoot(_registerUserEvent)
        };

        var newUserCommand = new NewUserCommand
        {
            Email = request.Email,
            Password = request.Password,
            Roles = new List<string>()
        };

        var data = await app.RegisterUser(newUserCommand);
        var response = new RegisterUserResponse
        {
            UserId = data.UserId,
            Email = data.Email,
            Disabled = data.Disabled,
        };
        return response;
    }

    public async Task<RegisterRoleResponse> RegisterRoleAsync(
        RegisterRoleRequest request,
        CallContext context = default
    )
    {
        var app = new Application<User, Role>(_userRepository, _roleRepository)
        {
            AggregateRoot = new SecurityAggregateRoot(_registerUserEvent)
        };

        var newRoleCommand = new NewRoleCommand
        {
            Name = request.Name,
            Description = request.Description
        };

        var data = await app.RegisterRole(newRoleCommand);
        var response = new RegisterRoleResponse
        {
            RoleId = data.RoleId,
            Name = data.Name,
            Description = data.Description,
            Disabled = data.Disabled,
        };
        return response;
    }

    public async Task<UpdateRoleResponse> UpdateRoleAsync(
        UpdateRoleRequest request,
        CallContext context = default
    )
    {
        var app = new Application<User, Role>(_userRepository, _roleRepository)
        {
            AggregateRoot = new SecurityAggregateRoot(_registerUserEvent)
        };

        var updateRoleCommand = new UpdateRoleCommand
        {
            RoleId = request.RoleId,
            Name = request.Name,
            Description = request.Description,
            Disable = request.Disable
        };

        var data = await app.UpdateRole(updateRoleCommand);
        var response = new UpdateRoleResponse
        {
            RoleId = data.RoleId,
            Name = data.Name,
            Description = data.Description,
            Disabled = data.Disabled,
        };
        return response;
    }
}
