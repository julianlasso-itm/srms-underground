using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class RegisterUserUseCase<TEntity>
    : BaseUseCase<NewUserCommand, RegisterUserResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IUserRepository<TEntity> _userRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}";

    public RegisterUserUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IUserRepository<TEntity> userRepository
    )
        : base(aggregateRoot)
    {
        _userRepository = userRepository;
    }

    public override async Task<RegisterUserResponse> Handle(NewUserCommand request)
    {
        var newUser = MapToRequestForDomain(request);
        var user = AggregateRoot.RegisterCredential(newUser);
        var response = MapToResponse(user);
        _ = await Persist(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private RegisterCredential MapToRequestForDomain(NewUserCommand request)
    {
        return new RegisterCredential { Email = request.Email, Password = request.Password, };
    }

    private RegisterUserResponse MapToResponse(RegisterCredentialResponse user)
    {
        return new RegisterUserResponse
        {
            UserId = user.CredentialId,
            Email = user.Email,
            Password = user.Password,
            Disabled = user.Disabled,
        };
    }

    private async Task<TEntity> Persist(RegisterUserResponse response)
    {
        return await _userRepository.AddAsync(response);
    }
}
