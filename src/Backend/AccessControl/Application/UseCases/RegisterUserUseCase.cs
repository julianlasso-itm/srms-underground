using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Interfaces;

namespace AccessControl.Application.UseCases;

public sealed class RegisterUserUseCase<TEntity> : IUseCase<NewUserCommand, RegisterUserResponse>
    where TEntity : class
{
    private readonly ISecurityAggregateRoot _aggregateRoot;
    private readonly IUserRepository<TEntity> _userRepository;

    public RegisterUserUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IUserRepository<TEntity> userRepository
    )
    {
        _aggregateRoot = aggregateRoot;
        _userRepository = userRepository;
    }

    public async Task<RegisterUserResponse> Handle(NewUserCommand request)
    {
        var user = _aggregateRoot.RegisterCredential(
            new RegisterCredential { Email = request.Email, Password = request.Password, }
        );

        var response = new RegisterUserResponse
        {
            UserId = user.CredentialId,
            Email = user.Email,
            Password = user.Password,
            Disabled = user.Disabled,
        };

        _ = await _userRepository.AddAsync(_userRepository.MapToEntity(response));
        _aggregateRoot.EmitEvent(
            $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}",
            JsonSerializer.Serialize(response)
        );
        return response;
    }
}
