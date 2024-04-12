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
        var user = AggregateRoot.RegisterCredential(
            new RegisterCredential { Email = request.Email, Password = request.Password }
        );

        var response = new RegisterUserResponse
        {
            UserId = user.CredentialId,
            Email = user.Email,
            Password = user.Password,
            Disabled = user.Disabled,
        };

        _ = await _userRepository.AddAsync(_userRepository.MapToEntity(response));
        EmitEvent(
            $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}",
            JsonSerializer.Serialize(response)
        );
        return response;
    }
}
