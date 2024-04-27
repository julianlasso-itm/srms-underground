using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Application.UseCases;
using Profiles.Domain.Aggregates.Interfaces;

namespace Profiles.Application;

public class Application<TRoleEntity>
    where TRoleEntity : class
{
    public required IPersonnelAggregateRoot AggregateRoot { get; init; }
    private readonly IRoleRepository<TRoleEntity> _roleRepository;

    public Application(IRoleRepository<TRoleEntity> roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<RegisterRoleApplicationResponse> RegisterRole(RegisterRoleCommand request)
    {
        var useCase = new RegisterRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateRoleApplicationResponse> UpdateRole(UpdateRoleCommand request)
    {
        var useCase = new UpdateRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteRoleApplicationResponse> DeleteRole(DeleteRoleCommand request)
    {
        var useCase = new DeleteRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<GetRolesApplicationResponse<TRoleEntity>> GetRoles(GetRolesCommand request)
    {
        var useCase = new GetRolesUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }
}
