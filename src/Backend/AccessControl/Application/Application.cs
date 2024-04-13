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

    public Task<RegisterUserResponse> RegisterUser(NewUserCommand request)
    {
        ValidateAggregateRoot();
        var useCase = new RegisterUserUseCase<TUserEntity>(AggregateRoot, _userRepository);
        var response = useCase.Handle(request);
        return response;
    }

    public Task<RegisterRoleResponse> RegisterRole(NewRoleCommand request)
    {
        ValidateAggregateRoot();
        var useCase = new RegisterRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        var response = useCase.Handle(request);
        return response;
    }

    private void ValidateAggregateRoot()
    {
        if (AggregateRoot == null)
        {
            throw new InvalidOperationException("AggregateRoot is not set.");
        }
    }
}
