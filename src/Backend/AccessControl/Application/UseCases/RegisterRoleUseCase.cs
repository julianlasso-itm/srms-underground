using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class RegisterRoleUseCase<TEntity>
    : BaseUseCase<NewRoleCommand, RegisterRoleResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleRegistered}";

    public RegisterRoleUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IRoleRepository<TEntity> roleRepository
    )
        : base(aggregateRoot)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<RegisterRoleResponse> Handle(NewRoleCommand request)
    {
        var newRole = MapToRequestForDomain(request);
        var role = AggregateRoot.RegisterRole(newRole);
        var response = MapToResponse(role);
        _ = await Persist(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private Domain.Aggregates.Dto.RegisterRole MapToRequestForDomain(NewRoleCommand request)
    {
        return new Domain.Aggregates.Dto.RegisterRole
        {
            Name = request.Name,
            Description = request.Description,
        };
    }

    private RegisterRoleResponse MapToResponse(Domain.Aggregates.Dto.RegisterRoleResponse role)
    {
        return new RegisterRoleResponse
        {
            RoleId = role.RoleId,
            Name = role.Name,
            Description = role.Description,
            Disabled = role.Disabled,
        };
    }

    private async Task<TEntity> Persist(RegisterRoleResponse response)
    {
        return await _roleRepository.AddAsync(response);
    }
}
