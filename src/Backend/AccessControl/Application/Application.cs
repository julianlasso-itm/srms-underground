using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Application.UseCases;
using AccessControl.Domain.Aggregates.Interfaces;

namespace AccessControl.Application;

public class Application<TUserEntity, TRoleEntity>
    where TUserEntity : class
    where TRoleEntity : class
{
    public required ISecurityAggregateRoot AggregateRoot { get; init; }

    private readonly IUserRepository<TUserEntity> _userRepository;
    private readonly IRoleRepository<TRoleEntity> _roleRepository;

    public Application(
        IUserRepository<TUserEntity> userRepository,
        IRoleRepository<TRoleEntity> roleRepository
    )
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public Task<RegisterUserApplicationResponse> RegisterUser(RegisterUserCommand request)
    {
        var useCase = new RegisterUserUseCase<TUserEntity>(AggregateRoot, _userRepository);
        return useCase.Handle(request);
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
