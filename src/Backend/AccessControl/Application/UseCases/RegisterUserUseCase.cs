using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class RegisterUserUseCase<TEntity>
    : BaseUseCase<RegisterUserCommand, RegisterUserApplicationResponse, ISecurityAggregateRoot>
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

    public override async Task<RegisterUserApplicationResponse> Handle(RegisterUserCommand request)
    {
        var newUser = MapToRequestForDomain(request);
        var user = AggregateRoot.RegisterCredential(newUser);
        var response = MapToResponse(user);
        _ = await Persistence(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private RegisterCredentialDomainRequest MapToRequestForDomain(RegisterUserCommand request)
    {
        return new RegisterCredentialDomainRequest
        {
            Email = request.Email,
            Password = request.Password,
        };
    }

    private RegisterUserApplicationResponse MapToResponse(RegisterCredentialDomainResponse user)
    {
        return new RegisterUserApplicationResponse
        {
            UserId = user.CredentialId,
            Email = user.Email,
            Password = user.Password,
            Disabled = user.Disabled,
        };
    }

    private async Task<TEntity> Persistence(RegisterUserApplicationResponse response)
    {
        return await _userRepository.AddAsync(response);
    }
}
