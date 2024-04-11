using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Interfaces;

namespace AccessControl.Application.UseCases;

public sealed class RegisterRoleUseCase<TEntity> : IUseCase<NewRoleCommand, RegisterRoleResponse>
    where TEntity : class
{
    private readonly ISecurityAggregateRoot _aggregateRoot;
    private readonly IRoleRepository<TEntity> _roleRepository;

    public RegisterRoleUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IRoleRepository<TEntity> roleRepository
    )
    {
        _aggregateRoot = aggregateRoot;
        _roleRepository = roleRepository;
    }

    public async Task<RegisterRoleResponse> Handle(NewRoleCommand request)
    {
        var dataRegisterRole = new Domain.Aggregates.Dto.RegisterRole
        {
            Name = request.Name,
            Description = request.Description,
        };
        var role = _aggregateRoot.RegisterRole(dataRegisterRole);

        var response = new RegisterRoleResponse
        {
            RoleId = role.RoleId,
            Name = role.Name,
            Description = role.Description,
            Disabled = role.Disabled,
        };

        var entity = _roleRepository.MapToEntity(response);
        _ = await _roleRepository.AddAsync(entity);
        return response;
    }
}
