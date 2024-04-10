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
    private readonly RegisterUserEvent _registerUserEvent;

    public AccessControlServices(
        IUserRepository<User> userRepository,
        RegisterUserEvent registerUserEvent
    )
    {
        _userRepository = userRepository;
        _registerUserEvent = registerUserEvent;
    }

    public async Task<RegisterUserResponse> RegisterUserAsync(
        RegisterUserRequest request,
        CallContext context = default
    )
    {
        var app = new Application<User>(_userRepository)
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
}
