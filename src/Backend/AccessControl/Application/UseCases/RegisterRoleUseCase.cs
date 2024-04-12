using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace AccessControl.Application.UseCases;

public sealed class RegisterRoleUseCase<TEntity>
    : BaseUseCase<NewRoleCommand, RegisterRoleResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;

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
        var dataRegisterRole = new Domain.Aggregates.Dto.RegisterRole
        {
            Name = request.Name,
            Description = request.Description,
        };
        var role = AggregateRoot.RegisterRole(dataRegisterRole);

        var response = new RegisterRoleResponse
        {
            RoleId = role.RoleId,
            Name = role.Name,
            Description = role.Description,
            Disabled = role.Disabled,
        };

        _ = await _roleRepository.AddAsync(_roleRepository.MapToEntity(response));
        EmitEvent(
            $"{EventsConst.Prefix}.{EventsConst.EventRoleRegistered}",
            JsonSerializer.Serialize(response)
        );
        return response;
    }
}
